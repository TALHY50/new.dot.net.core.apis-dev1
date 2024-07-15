using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Notification.Application.Infrastructure.Persistence;
using Notification.Main.Application.Common;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.Main.Application.Features.Notifications.Outgoing;

public class CreateWebOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/web/create")]
    public async Task<ActionResult<int>> Create(CreateWebOutgoingCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateWebOutgoingCommand() : IRequest<int>;

internal sealed class CreateWebOutgoingCommandValidator : AbstractValidator<CreateWebOutgoingCommand>
{
    public CreateWebOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CreateWebOutgoingCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateWebOutgoingCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateWebOutgoingCommand request, CancellationToken cancellationToken)
    {
        var events = await _context.Events.Where(e => e.Status == 0).ToListAsync(cancellationToken: cancellationToken);

        foreach (var @event in events)
        {
            return 1;
        }

        return 0;
    }
}