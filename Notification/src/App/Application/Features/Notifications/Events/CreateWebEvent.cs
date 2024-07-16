using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Common;
using Notification.App.Contracts;
using Notification.App.Domain.Notifications.Events;
using Notification.App.Domain.Setups;
using Notification.App.Domain.ValueObjects;
using Notification.App.Infrastructure.Persistence;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.App.Application.Features.Notifications.Event;

public class CreateWebEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/web/create")]
    public async Task<ActionResult<int>> Create(CreateWebEventCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateWebEventCommand(
    ReferenceUniqueId ReferenceUniqueId,
    CategoricalData CategoricalData,
    WebReceivers Receivers,
    MiscellaneousInformation Information) : IRequest<int>;
internal sealed class CreateWebEventCommandValidator : AbstractValidator<CreateWebEventCommand>
{
    public CreateWebEventCommandValidator()
    {
        RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateWebEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateWebEventCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateWebEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new Domain.Notifications.Events.Event
        {
            Category = request.CategoricalData.Category,
            Name = request.CategoricalData.Name,
            IsWeb = true,
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
            Url = request.Receivers.Url,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.AppEventData.Add(appEventData);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var credential = await _context.Credentials.FirstAsync(e => e.Type == NotificationType.Web, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (credential == null)
        {
            throw new Exception("credential not found");
        }

        ReceiverGroup? receiverGroup = null;
        int receiverGroupId = 0;

        if (request.Receivers.IsAllowFromApp == false)
        {
            receiverGroup = await _context.ReceiverGroups.FirstAsync(e => e != null && e.Type == NotificationType.Web, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (receiverGroup == null)
            {
                throw new Exception("receiver group not found");
            }

            receiverGroupId = receiverGroup.Id;
        }

        var webEvent = new WebEvent()
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = credential.Id,
            NotificationReceiverGroupId = receiverGroupId,
            Name = request.CategoricalData.Name,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.WebEvents.Add(webEvent);

        await _context.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }
}