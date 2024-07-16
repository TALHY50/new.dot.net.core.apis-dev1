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
using Notification.RazorTemplateEngine.Services;

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

internal sealed class CreateEmailOutgoingCommandHandler(ILogger<CreateSmsOutgoingCommandHandler> logger, ApplicationDbContext context, IRazorViewToStringRenderer razorViewToStringRenderer) : IRequestHandler<CreateEmailOutgoingCommand, int>
{
     private readonly ApplicationDbContext _context = context;
     private readonly IRazorViewToStringRenderer _razorViewToStringRenderer = razorViewToStringRenderer;
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

        var viewModelType = TemplateMap.GetViewModelType(eventTemplate.Content);
        if (viewModelType == null)
        {
            throw new ArgumentException("Template not registered or ViewModel type not found for the specified template path.");
        }

        var viewModel = JsonConvert.DeserializeObject(eventTemplate.Variables, viewModelType);

        string content = await _razorViewToStringRenderer.RenderViewToStringAsync($"{eventTemplate.Path + eventTemplate.Content}.cshtml", viewModel).ConfigureAwait(false);

       // content = await _engine.RenderTemplate($"{eventTemplate.Content}.cshtml", eventTemplate.Variables).ConfigureAwait(false);
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

        return emailOutgoing.Id;
    }
}