using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Notification.App.Domain.Entities.Outgoings;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Models;

using EventId = Notification.App.Contracts.EventId;
using ILogger = Serilog.ILogger;

namespace Notification.App.Application.Features.Notifications.Outgoing;

public record CreateWebOutgoingCommand(EventId EventId) : IRequest<ErrorOr<WebOutgoing>>;

public class CreateWebOutgoingCommandValidator : AbstractValidator<CreateWebOutgoingCommand>
{
    public CreateWebOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

public class CreateWebOutgoingCommandHandler(ILogger<CreateWebOutgoingCommandHandler> logger, ApplicationDbContext context, IRenderer renderer) : IRequestHandler<CreateWebOutgoingCommand, ErrorOr<WebOutgoing>>
{
     private readonly ApplicationDbContext _context = context;
     private readonly IRenderer _renderer = renderer;
     private readonly ILogger<CreateWebOutgoingCommandHandler> _logger = logger;
     public async Task<ErrorOr<WebOutgoing>> Handle(CreateWebOutgoingCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var baseEvent = await _context.Events.Where(e => e.Id == request.EventId.Value).Where(e => e.Status == 0).Where(e => e.IsWeb == true).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (baseEvent == null)
        {
            return Error.NotFound("Base event not found");
        }

        var mainEvent = await _context.WebEvents.Where(e => e.NotificationEventId == baseEvent.Id).FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        if (mainEvent == null)
        {
            return Error.NotFound("Main event not found!");
        }

        var appEventData = await _context.AppEventData.Where(e => e.NotificationEventId == baseEvent.Id)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (appEventData == null)
        {
            return Error.NotFound("Event data not found!");
        }

        var receiverGroup = await _context.ReceiverGroups.Where(e => e.Id == mainEvent.NotificationReceiverGroupId)
            .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        if (receiverGroup == null)
        {
            return Error.NotFound("Receiver group not found!");
        }

        var to = receiverGroup.To;

        if (mainEvent.IsAllowFromApp)
        {
            to = to + "," + appEventData.Url;
        }

        var outgoing = new WebOutgoing()
        {
            NotificationEventId = baseEvent.Id,
            NotificationEventName = mainEvent.Name,
            NotificationCredentialId = mainEvent.NotificationCredentialId,
            Host = to,
            Content = appEventData.Data,
            CompanyId = receiverGroup.CompanyId,
            Status = 0,
            CreatedAt = now,
            UpdatedAt = now,
        };

        _context.WebOutgoings.Add(outgoing);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        baseEvent.Status = Status.Completed.Type;

        _context.Events.Remove(baseEvent);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.WebEvents.Remove(mainEvent);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _context.AppEventData.Remove(appEventData);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return outgoing;
    }
}