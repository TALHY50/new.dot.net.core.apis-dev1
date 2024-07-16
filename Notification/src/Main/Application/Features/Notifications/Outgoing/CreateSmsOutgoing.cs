using ACL.Application.Domain.Notifications.Outgoings;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using Notification.Main.Application.Common;
using Notification.Main.Application.Common.Interfaces;
using Notification.Main.Infrastructure.Persistence;
using Notification.Renderer.Services;

using EventId = ACL.Application.Contracts.EventId;

namespace Notification.Main.Application.Features.Notifications.Outgoing;

public class CreateSmsOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/sms/create")]
    public async Task<ActionResult<int>> Create(CreateSmsOutgoingCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateSmsOutgoingCommand(EventId EventId) : IRequest<int>;

internal sealed class CreateSmsOutgoingCommandValidator : AbstractValidator<CreateSmsOutgoingCommand>
{
    public CreateSmsOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CreateSmsOutgoingCommandHandler(ILogger<CreateSmsOutgoingCommandHandler> logger, ApplicationDbContext context, IRenderer renderer) : IRequestHandler<CreateSmsOutgoingCommand, int>
{
     private readonly ApplicationDbContext _context = context;
     private readonly IRenderer _renderer = renderer;
     private readonly ILogger _logger = logger;
     public async Task<int> Handle(CreateSmsOutgoingCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var baseEvent = await _context.Events.Where(e => e.Id == request.EventId.Value).Where(e => e.Status == 0).Where(e => e.IsSms == true).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (baseEvent == null)
        {
            throw new Exception("Base event not found");
        }

        var mainEvent = await _context.SmsEvents.Where(e => e.NotificationEventId == baseEvent.Id).FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        if (mainEvent == null)
        {
            throw new Exception("Main event not found");
        }

        var appEventData = await _context.AppEventData.Where(e => e.NotificationEventId == baseEvent.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (appEventData == null)
        {
            throw new Exception("Event data not found");
        }

        var eventTemplate = await _context.EventTemplates.Where(e => e.NotificationEventId == baseEvent.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (eventTemplate == null)
        {
            throw new Exception("Template not found");
        }

        var receiverGroup = await _context.ReceiverGroups.Where(e => e.Id == mainEvent.NotificationReceiverGroupId)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (receiverGroup == null)
        {
            throw new Exception("Receiver group not found");
        }

        var to = receiverGroup.To;

        if (mainEvent.IsAllowFromApp)
        {
            to = to + "," + appEventData.Receivers;
        }

        Type modelType = TemplateMap.GetModelType(eventTemplate.Content);

        var model = JsonConvert.DeserializeObject(eventTemplate.Variables, modelType);

        var content = await _renderer.RenderViewToStringAsync($"{eventTemplate.Path + eventTemplate.Content}.cshtml", model).ConfigureAwait(false);

        var outgoing = new SmsOutgoing()
        {
            NotificationEventId = baseEvent.Id,
            NotificationEventName = mainEvent.Name,
            NotificationCredentialId = mainEvent.NotificationCredentialId,
            Content = content,
            To = to,
            CompanyId = eventTemplate.CompanyId,
            Status = 0,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.SmsOutgoings.Add(outgoing);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        baseEvent.Status = 1;
        eventTemplate.Status = 1;

        _context.Events.Remove(baseEvent);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.EventTemplates.Remove(eventTemplate);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.SmsEvents.Remove(mainEvent);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.AppEventData.Remove(appEventData);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return outgoing.Id;
    }
}