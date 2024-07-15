using ACL.Application.Contracts;
using ACL.Application.Domain.Notifications.Events;
using ACL.Application.Domain.Setups;
using ACL.Application.Domain.ValueObjects;
using ACL.Application.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notification.Main.Application.Common;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.Main.Application.Features.Notifications.Event;

public class CreateSmsEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/sms/create")]
    public async Task<ActionResult<int>> Create(CreateSmsEventCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateSmsEventCommand(
    ReferenceUniqueId ReferenceUniqueId,
    CategoricalData CategoricalData,
    Content Content,
    SmsReceivers Receivers,
    MiscellaneousInformation Information) : IRequest<int>;

internal sealed class CreateSmsEventCommandValidator : AbstractValidator<CreateSmsEventCommand>
{
    public CreateSmsEventCommandValidator()
    {
        RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateSmsEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateSmsEventCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateSmsEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new ACL.Application.Domain.Notifications.Events.Event
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
            Data = request.CategoricalData.Data,
            Receivers = request.Receivers.Receivers,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.AppEventData.Add(appEventData);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var credential = await _context.Credentials.FirstAsync(e => e.Type == NotificationType.Sms, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (credential == null)
        {
            throw new Exception("credential not found");
        }

        ReceiverGroup? receiverGroup = null;
        int receiverGroupId = 0;

        if (request.Receivers.IsAllowFromApp == false)
        {
            receiverGroup = await _context.ReceiverGroups.FirstAsync(e => e != null && e.Type == NotificationType.Sms, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (receiverGroup == null)
            {
                throw new Exception("receiver group not found");
            }

            receiverGroupId = receiverGroup.Id;
        }

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

        return @event.Id;
    }
}