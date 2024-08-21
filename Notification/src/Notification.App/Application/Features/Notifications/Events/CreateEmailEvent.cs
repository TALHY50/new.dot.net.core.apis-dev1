using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Domain.Notifications.Events;
using SharedKernel.Main.Domain.Setups;
using SharedKernel.Main.Domain.ValueObjects;
using SharedKernel.Main.Infrastructure.Persistence;

namespace SharedKernel.Main.Application.Features.Notifications.Events;

public class CreateEmailEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/email/create")]
    public async Task<ActionResult<ErrorOr<Event>>> Create(CreateEmailEventCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record CreateEmailEventCommand(
    ReferenceUniqueId ReferenceUniqueId,
    CategoricalData CategoricalData,
    Content Content,
    EmailReceivers Receivers,
    MiscellaneousInformation Information) : IRequest<ErrorOr<Event>>;

internal sealed class CreateEmailEventCommandValidator : AbstractValidator<CreateEmailEventCommand>
{
    public CreateEmailEventCommandValidator()
    {
        RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateEmailEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateEmailEventCommand, ErrorOr<Event>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<Event>> Handle(CreateEmailEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new Domain.Notifications.Events.Event
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
            return Error.NotFound("Credential not found!");
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
    }
}