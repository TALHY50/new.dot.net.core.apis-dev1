using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Extensions;
using SharedKernel.Main.Infrastructure.Mappings;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Notification.Domain.Entities.Outgoings;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

using EventId = SharedKernel.Main.Notification.Contracts.EventId;

namespace Notification.App.Application.Features.Notifications.Outgoing;

public class CreateEmailOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/email/create")]
    public async Task<ActionResult<ErrorOr<EmailOutgoing>>> Create(CreateEmailOutgoingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record CreateEmailOutgoingCommand(EventId EventId) : IRequest<ErrorOr<EmailOutgoing>>;

internal sealed class CreateEmailOutgoingCommandValidator : AbstractValidator<CreateEmailOutgoingCommand>
{
    public CreateEmailOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CreateEmailOutgoingCommandHandler(ILogger<CreateSmsOutgoingCommandHandler> logger, ApplicationDbContext context, IRenderer renderer) : IRequestHandler<CreateEmailOutgoingCommand, ErrorOr<EmailOutgoing>>
{
     private readonly ApplicationDbContext _context = context;
     private readonly IRenderer _renderer = renderer;
     private readonly ILogger _logger = logger;
     public async Task<ErrorOr<EmailOutgoing>> Handle(CreateEmailOutgoingCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = await _context.Events.Where(e => e.Id == request.EventId.Value).Where(e => e.Status == 0).Where(e => e.IsEmail == true).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (@event == null)
        {
            return Error.NotFound("Base event not found!");
        }

        var emailEvent = await _context.EmailEvents.Where(e => e.NotificationEventId == @event.Id).FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        if (emailEvent == null)
        {
            return Error.NotFound("Main event not found");
        }

        var appEventData = await _context.AppEventData.Where(e => e.NotificationEventId == @event.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (appEventData == null)
        {
            return Error.NotFound("Event data not found!");
        }

        var eventTemplate = await _context.EventTemplates.Where(e => e.NotificationEventId == @event.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (eventTemplate == null)
        {
            return Error.NotFound("Template not found!");
        }

        var receiverGroup = await _context.ReceiverGroups.Where(e => e.Id == emailEvent.NotificationReceiverGroupId)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (receiverGroup == null)
        {
            return Error.NotFound("Receiver group not found!");
        }

        bool isAttachment = appEventData.AttachmentInfo.Safe().Any();

        var to = receiverGroup.To;

        if (emailEvent.IsAllowFromApp)
        {
            to = to + "," + appEventData.Receivers;
        }

        var cc = string.Empty;

        if (emailEvent.IsAllowCc)
        {
            cc = receiverGroup.CcEmails;
        }

        var bcc = string.Empty;

        if (emailEvent.IsAllowBcc)
        {
            bcc = receiverGroup.BccEmails;
        }

        var viewModelType = TemplateMap.GetModelType(eventTemplate.Content);
        if (viewModelType == null)
        {
            throw new ArgumentException("Template not registered or ViewModel type not found for the specified template path.");
        }

        var viewModel = JsonConvert.DeserializeObject(eventTemplate.Variables, viewModelType);

        string content = await _renderer.RenderViewToStringAsync($"{eventTemplate.Path + eventTemplate.Content}.cshtml", viewModel).ConfigureAwait(false);

        var emailOutgoing = new EmailOutgoing()
        {
            NotificationEventId = @event.Id,
            NotificationEventName = emailEvent.Name,
            NotificationCredentialId = emailEvent.NotificationCredentialId,
            Subject = eventTemplate.Subject,
            Content = content,
            To = to,
            Cc = cc,
            Bcc = bcc,
            IsAttachment = isAttachment,
            AttachmentDetails = appEventData.AttachmentInfo,
            CompanyId = eventTemplate.CompanyId,
            Status = 0,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.EmailOutgoings.Add(emailOutgoing);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        @event.Status = 1;
        eventTemplate.Status = 1;

        _context.Events.Remove(@event);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.EventTemplates.Remove(eventTemplate);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.EmailEvents.Remove(emailEvent);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.AppEventData.Remove(appEventData);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return emailOutgoing;
    }
}