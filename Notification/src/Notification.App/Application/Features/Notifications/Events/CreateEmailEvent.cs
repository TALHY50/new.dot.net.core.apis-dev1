using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using Notification.App.Contracts;
using Notification.App.Domain.Entities.Events;
using Notification.App.Domain.Entities.Setups;
using Notification.App.Domain.Entities.ValueObjects;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Contracts;

using ProblemDetails = FastEndpoints.ProblemDetails;

namespace Notification.App.Application.Features.Notifications.Events;

public record CreateEmailEventCommand(
    ReferenceUniqueId ReferenceUniqueId,
    CategoricalData CategoricalData,
    Content Content,
    EmailReceivers Receivers,
    MiscellaneousInformation Information) : IRequest<ErrorOr<Event>>;

public class CreateEmailEventCommandValidator : AbstractValidator<CreateEmailEventCommand>
{
    public CreateEmailEventCommandValidator()
    {
        RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(20)
            .NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class CreateEmailEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateEmailEventCommand, ErrorOr<Event>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<Event>> Handle(CreateEmailEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new Event
        {
            Category = request.CategoricalData.Category,
            Name = request.CategoricalData.Name,
            IsEmail = true,
            IsAllowFromApp = request.Receivers.IsAllowFromApp,
            CreatedById = request.Information.CreatedById,
            UpdatedById = request.Information.CreatedById,
            Status = 0,
            CreatedAt = now,
            UpdatedAt = now,
        };
        _context.Events.Add(@event);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var appEventData = new AppEventData
        {
            NotificationEventId = @event.Id,
            ReferenceUniqueId = request.ReferenceUniqueId.Value,
            Data = request.CategoricalData.Data.ToString(),
            AttachmentInfo = request.Content.AttachmentInfo,
            Receivers = request.Receivers.Receivers,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.AppEventData.Add(appEventData);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var credential = await _context.Credentials.FirstAsync(e => e.Type == NotificationType.Mail, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (credential == null)
        {
            return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Credential not found!");
        }

        ReceiverGroup? receiverGroup = null;
        int receiverGroupId = 0;

        receiverGroup = await _context.ReceiverGroups.FirstAsync(e => e != null && e.Type == NotificationType.Mail, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (receiverGroup == null)
        {
            return Error.NotFound("Receiver group not found!");
        }

        receiverGroupId = receiverGroup.Id;

        var emailEvent = new EmailEvent
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = credential.Id,
            NotificationReceiverGroupId = receiverGroupId,
            Name = request.CategoricalData.Name,
            IsAllowFromApp = request.Receivers.IsAllowFromApp,
            IsAllowCc = request.Receivers.IsAllowCc,
            IsAllowBcc = request.Receivers.IsAllowBcc,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.EmailEvents.Add(emailEvent);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var entity = new EventTemplate
        {
            NotificationEventId = @event.Id,
            Type = NotificationType.Mail,
            Language = request.Content.Language,
            Subject = request.Content.Subject,
            Content = request.Content.ContentTemplateName,
            Path = request.Content.ContentTemplatePath,
            Variables = request.Content.ContentTemplateModel.ToString(),
            Status = 0,
            CompanyId = request.Information.CompanyId,
            CreatedById = request.Information.CreatedById,
            UpdatedById = request.Information.CreatedById,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.EventTemplates.Add(entity);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return @event;
#pragma warning restore CS0162 // Unreachable code detected
    }
}