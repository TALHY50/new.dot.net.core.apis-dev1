using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;
using SharedKernel.Main.Infrastructure.Mappings;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

using EventId = SharedKernel.Main.Contracts.Notificaiton.EventId;

namespace Notification.App.Application.Features.Notifications.Outgoing;

public class CreateSmsOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/sms/create")]
    public async Task<ActionResult<ErrorOr<SmsOutgoing>>> Create(CreateSmsOutgoingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record CreateSmsOutgoingCommand(EventId EventId) : IRequest<ErrorOr<SmsOutgoing>>;

internal sealed class CreateSmsOutgoingCommandValidator : AbstractValidator<CreateSmsOutgoingCommand>
{
    public CreateSmsOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CreateSmsOutgoingCommandHandler(ILogger<CreateSmsOutgoingCommandHandler> logger, ApplicationDbContext context, IRenderer renderer) : IRequestHandler<CreateSmsOutgoingCommand, ErrorOr<SmsOutgoing>>
{
     private readonly ApplicationDbContext _context = context;
     private readonly IRenderer _renderer = renderer;
     private readonly ILogger _logger = logger;
     public async Task<ErrorOr<SmsOutgoing>> Handle(CreateSmsOutgoingCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var baseEvent = await _context.Events.Where(e => e.Id == request.EventId.Value).Where(e => e.Status == 0).Where(e => e.IsSms == true).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (baseEvent == null)
        {
            return Error.NotFound("Base event not found");
        }

        var mainEvent = await _context.SmsEvents.Where(e => e.NotificationEventId == baseEvent.Id).FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        if (mainEvent == null)
        {
            return Error.NotFound("Main event not found!");
        }

        var appEventData = await _context.AppEventData.Where(e => e.NotificationEventId == baseEvent.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (appEventData == null)
        {
            return Error.NotFound("Event data not found!");
        }

        var eventTemplate = await _context.EventTemplates.Where(e => e.NotificationEventId == baseEvent.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (eventTemplate == null)
        {
            return Error.NotFound("Template not found!");
        }

        var receiverGroup = await _context.ReceiverGroups.Where(e => e.Id == mainEvent.NotificationReceiverGroupId)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (receiverGroup == null)
        {
            return Error.NotFound("Receiver group not found!");
        }

        var to = receiverGroup.To;

        if (mainEvent.IsAllowFromApp)
        {
            to = to + "," + appEventData.Receivers;
        }

        Type type = TemplateMap.GetModelType(eventTemplate.Content);

        var model = JsonConvert.DeserializeObject(eventTemplate.Variables, type);

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

        return outgoing;
    }
}