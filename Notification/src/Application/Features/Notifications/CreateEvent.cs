using System.Runtime.InteropServices.Marshalling;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.Application.Common;
using Notification.Application.Domain.Notifications.Events;
using Notification.Application.Infrastructure.Persistence;

namespace Notification.Application.Features.Notifications;

public class CreateEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/create")]
    public async Task<ActionResult<int>> Create(CreateEventCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateEventCommand(
    string Category,
    string Name,
    bool IsEmail,
    bool IsSms,
    bool IsWeb,
    bool IsAllowFromApp = false,
    int CreatedById = 0,
    string ReferenceUniqueId = "",
    string Data = "",
    string AttachmentInfo = "",
    string Receivers = "",
    string Url = "",
    string Path = "",
    bool IsAllowCc = false,
    bool IsAllowBcc = false,
    string Subject = "",
    string Content = "",
    int Type = 0,
    string Variables = "",
    string Language = "",
    int CompanyId = 0) : IRequest<int>;
internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(v => v.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateEventCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new Event
        {
            Category = request.Category,
            Name = request.Name,
            IsEmail = request.IsEmail,
            IsSms = request.IsSms,
            IsWeb = request.IsWeb,
            IsAllowFromApp = request.IsAllowFromApp,
            CreatedById = request.CreatedById,
            UpdatedById = request.CreatedById, // assuming the creator is also the updater initially
            Status = 0,
            CreatedAt = now,
            UpdatedAt = now,
        };
        _context.Event.Add(@event);

        await _context.SaveChangesAsync(cancellationToken);

        var appEventData = new AppEventData
        {
            NotificationEventId = @event.Id,
            ReferenceUniqueId = request.ReferenceUniqueId,
            Data = request.Data,
            AttachmentInfo = request.AttachmentInfo,
            Receivers = request.Receivers,
            Url = request.Url,
            Path = request.Path,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.AppEventData.Add(appEventData);

        await _context.SaveChangesAsync(cancellationToken);

        var emailEvent = new EmailEvent
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = 1, // todo
            NotificationReceiverGroupId = 1, // todo
            Name = request.Name,
            IsAllowFromApp = request.IsAllowFromApp,
            IsAllowCc = request.IsAllowCc,
            IsAllowBcc = request.IsAllowBcc,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.EmailEvent.Add(emailEvent);

        await _context.SaveChangesAsync(cancellationToken);

        var webEvent = new WebEvent
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = 1, // todo
            NotificationReceiverGroupId = 1, // todo
            Name = request.Name,
            IsAllowFromApp = request.IsAllowFromApp,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.WebEvent.Add(webEvent);

        await _context.SaveChangesAsync(cancellationToken);

        var smsEvent = new SmsEvent
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = 1, // todo
            NotificationReceiverGroupId = 1, // todo
            Name = request.Name,
            IsAllowFromApp = request.IsAllowFromApp,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.SmsEvent.Add(smsEvent);

        await _context.SaveChangesAsync(cancellationToken);

        var entity = new EventTemplate
        {
            NotificationEventId = @event.Id,
            Subject = request.Subject,
            Content = request.Content,
            Path = request.Path,
            Type = request.Type,
            Variables = request.Variables,
            CreatedById = request.CreatedById,
            UpdatedById = request.CreatedById,
            Status = 0,
            Language = request.Language,
            CompanyId = request.CompanyId,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.EventTemplate.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return 0;
    }
}