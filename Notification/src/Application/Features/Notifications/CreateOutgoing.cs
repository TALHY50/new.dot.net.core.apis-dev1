using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.Application.Common;
using Notification.Application.Domain.Notifications.Events;
using Notification.Application.Domain.Todos;
using Notification.Application.Features.TodoItems;
using Notification.Application.Infrastructure.Persistence;

namespace Notification.Application.Features.Notifications;

public class CreateOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/create")]
    public async Task<ActionResult<int>> Create(CreateOutgoingCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateOutgoingCommand(Event Event) : IRequest<int>;

internal sealed class CreateOutgoingCommandValidator : AbstractValidator<CreateOutgoingCommand>
{
    public CreateOutgoingCommandValidator()
    {
        RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateOutgoingCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateOutgoingCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateOutgoingCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
        };

        entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

        _context.TodoItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}