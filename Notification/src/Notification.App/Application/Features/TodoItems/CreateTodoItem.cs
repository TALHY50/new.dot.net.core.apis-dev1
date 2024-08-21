using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Infrastructure.Persistence;
using Notification.Main.Infrastructure.Persistence;

using SharedKernel.Main.Application.Common.Common;
using SharedKernel.Main.Domain.Notification.Todos;

namespace Notification.App.Application.Features.TodoItems;

public class CreateTodoItemController : ApiControllerBase
{
    [HttpPost("/api/create-outgoing")]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateTodoItemCommand(int ListId, string? Title) : IRequest<int>;

internal sealed class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateToDoItemCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
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