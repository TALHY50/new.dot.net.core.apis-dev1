using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using ACL.Application.Domain.Notifications.Events;
using ACL.Application.Domain.Notifications.Outgoings;
using ACL.Application.Infrastructure.Persistence;
using Notification.Main.Application.Common;
using Notification.Main.Application.Common.Interfaces;
using Notification.Main.Infrastructure.Persistence;
using Notification.Main.Infrastructure.Services;

using EventId = ACL.Application.Contracts.EventId;

namespace Notification.Main.Application.Features.Notifications.Outgoing;

public class CreateEmailOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/email/create")]
    public async Task<ActionResult<int>> Create(CreateEmailOutgoingCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateEmailOutgoingCommand(EventId EventId) : IRequest<int>;

internal sealed class CreateEmailOutgoingCommandValidator : AbstractValidator<CreateEmailOutgoingCommand>
{
    public CreateEmailOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CreateEmailOutgoingCommandHandler(ILogger<CreateSmsOutgoingCommandHandler> logger, ApplicationDbContext context, ITemplateExecutionEngine engine) : IRequestHandler<CreateEmailOutgoingCommand, int>
{
     private readonly ApplicationDbContext _context = context;
     private readonly ITemplateExecutionEngine _engine = engine;
     private readonly ILogger _logger = logger;
     public async Task<int> Handle(CreateEmailOutgoingCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = await _context.Events.Where(e => e.Id == request.EventId.Value).Where(e => e.Status == 0).Where(e => e.IsEmail == true).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (@event == null)
        {
            throw new Exception("event not found");
        }

        var emailEvent = await _context.EmailEvents.Where(e => e.NotificationEventId == @event.Id).FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        if (emailEvent == null)
        {
            throw new Exception("email event not found");
        }

        var appEventData = await _context.AppEventData.Where(e => e.NotificationEventId == @event.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (appEventData == null)
        {
            throw new Exception("app event data not found");
        }

        var eventTemplate = await _context.EventTemplates.Where(e => e.NotificationEventId == @event.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (eventTemplate == null)
        {
            throw new Exception("event template not found");
        }

        var receiverGroup = await _context.ReceiverGroups.Where(e => e.Id == emailEvent.NotificationReceiverGroupId)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (receiverGroup == null)
        {
            throw new Exception("receiver group not found");
        }

        bool isAttachment = !appEventData.AttachmentInfo.IsNullOrEmpty();

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

        string content = await _engine.RenderTemplate($"{eventTemplate.Content}.cshtml", eventTemplate.Variables).ConfigureAwait(false);

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

        return emailOutgoing.Id;
    }
}