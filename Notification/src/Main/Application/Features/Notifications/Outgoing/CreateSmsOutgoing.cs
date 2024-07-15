using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ACL.Application.Domain.Notifications.Events;
using ACL.Application.Infrastructure.Persistence;
using Notification.Main.Application.Common;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.Main.Application.Features.Notifications.Outgoing;

public class CreateSmsOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/sms/create")]
    public async Task<ActionResult<int>> Create(CreateSmsOutgoingCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateSmsOutgoingCommand(EmailEvent Event) : IRequest<int>;

internal sealed class CreateSmsOutgoingCommandValidator : AbstractValidator<CreateSmsOutgoingCommand>
{
    public CreateSmsOutgoingCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CreateSmsOutgoingCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateSmsOutgoingCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateSmsOutgoingCommand request, CancellationToken cancellationToken)
    {
        var events = await _context.Events.Where(e => e.Status == 0).ToListAsync(cancellationToken: cancellationToken);

        foreach (var @event in events)
        {
            return 1;
        }

        return 0;
    }
}