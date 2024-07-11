using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.Application.Common;
using Notification.Application.Domain.Todos;
using Notification.Application.Features.TodoItems;
using Notification.Application.Infrastructure.Persistence;

namespace Notification.Application.Features.Notifications;

public class CreateEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/create")]
    public async Task<ActionResult<int>> Create(CreateEventCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateEventCommand(int ListId, string? Title) : IRequest<int>;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateEventCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateEventCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false,
        };

        entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

        _context.TodoItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}