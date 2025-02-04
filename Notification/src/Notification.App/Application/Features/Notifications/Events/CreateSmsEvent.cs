using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Notification.App.Contracts;
using Notification.App.Domain.Entities.Events;
using Notification.App.Domain.Entities.Setups;
using Notification.App.Domain.Entities.ValueObjects;
using Notification.App.Infrastructure.Persistence.Context;

using Result = SharedKernel.Main.Application.Models.Result;

namespace Notification.App.Application.Features.Notifications.Events;

public record CreateSmsEventCommand(
    ReferenceUniqueId ReferenceUniqueId,
    CategoricalData CategoricalData,
    Content Content,
    SmsReceivers Receivers,
    MiscellaneousInformation Information) : IRequest<ErrorOr<Event>>;

public class CreateSmsEventCommandValidator : AbstractValidator<CreateSmsEventCommand>
{
    public CreateSmsEventCommandValidator()
    {
        RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class CreateSmsEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateSmsEventCommand, ErrorOr<Event>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<Event>> Handle(CreateSmsEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new Event
        {
            Category = request.CategoricalData.Category,
            Name = request.CategoricalData.Name,
            IsSms = true,
            IsAllowFromApp = request.Receivers.IsAllowFromApp,
            Status = 0,
            CreatedById = request.Information.CreatedById,
            UpdatedById = request.Information.CreatedById,
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
            Receivers = request.Receivers.Receivers,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.AppEventData.Add(appEventData);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var credential = await _context.Credentials.FirstAsync(e => e.Type == NotificationType.Sms, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (credential is null)
        {
            return Error.NotFound("Credential not found!");
        }

        ReceiverGroup? receiverGroup = null;
        int receiverGroupId = 0;

        receiverGroup = await _context.ReceiverGroups.FirstAsync(e => e != null && e.Type == NotificationType.Sms, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (receiverGroup == null)
        {
            return Error.NotFound("Receiver group not found!");
        }

        receiverGroupId = receiverGroup.Id;

        var smsEvent = new SmsEvent
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = credential.Id,
            NotificationReceiverGroupId = receiverGroupId,
            Name = request.CategoricalData.Name,
            IsAllowFromApp = request.Receivers.IsAllowFromApp,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.SmsEvents.Add(smsEvent);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var entity = new EventTemplate();

        entity.NotificationEventId = @event.Id;
        entity.Language = request.Content.Language;
        entity.Subject = request.Content.Subject;
        entity.Content = request.Content.ContentTemplateName;
        entity.Path = request.Content.ContentTemplatePath;
        entity.Type = NotificationType.Sms;
        entity.Variables = request.Content.ContentTemplateModel.ToString();
        entity.CompanyId = request.Information.CompanyId;
        entity.Status = 0;
        entity.CreatedById = request.Information.CreatedById;
        entity.UpdatedById = request.Information.CreatedById;
        entity.CreatedAt = now;
        entity.UpdatedAt = now;

        _context.EventTemplates.Add(entity);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return @event;
    }
}