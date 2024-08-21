using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SharedKernel.Main.Application.Common.Common;
using SharedKernel.Main.Contracts.Notificaiton.Contracts;
using SharedKernel.Main.Domain.Notification.Notifications.Events;
using SharedKernel.Main.Domain.Notification.Setups;
using SharedKernel.Main.Domain.Notification.ValueObjects;
using SharedKernel.Main.Infrastructure.Persistence;

namespace Notification.App.Application.Features.Notifications.Events;

public class CreateWebEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/web/create")]
    public async Task<ActionResult<ErrorOr<Event>>> Create(CreateWebEventCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record CreateWebEventCommand(
    ReferenceUniqueId ReferenceUniqueId,
    CategoricalData CategoricalData,
    WebReceivers Receivers,
    MiscellaneousInformation Information) : IRequest<ErrorOr<Event>>;
internal sealed class CreateWebEventCommandValidator : AbstractValidator<CreateWebEventCommand>
{
    public CreateWebEventCommandValidator()
    {
        RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateWebEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateWebEventCommand, ErrorOr<Event>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<Event>> Handle(CreateWebEventCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var @event = new Event
        {
            Category = request.CategoricalData.Category,
            Name = request.CategoricalData.Name,
            IsWeb = true,
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
            Url = request.Receivers.Url,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.AppEventData.Add(appEventData);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var credential = await _context.Credentials.FirstAsync(e => e.Type == NotificationType.Web, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (credential is null)
        {
            return Error.NotFound("Credential not found!");
        }

        ReceiverGroup? receiverGroup = null;
        int receiverGroupId = 0;

        receiverGroup = await _context.ReceiverGroups.FirstAsync(e => e != null && e.Type == NotificationType.Web, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (receiverGroup == null)
        {
            return Error.NotFound("Receiver group not found!");
        }

        receiverGroupId = receiverGroup.Id;

        var webEvent = new WebEvent()
        {
            NotificationEventId = @event.Id,
            NotificationCredentialId = credential.Id,
            NotificationReceiverGroupId = receiverGroupId,
            IsAllowFromApp = @event.IsAllowFromApp,
            Name = request.CategoricalData.Name,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.WebEvents.Add(webEvent);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return @event;
    }
}