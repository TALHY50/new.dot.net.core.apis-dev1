using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Domain.Entities.Todos;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Exceptions;

namespace Notification.App.Application.Features.TodoItems;

public class TodoItemsController : ApiControllerBase
{
    [HttpPut("/api/todo-items/{id}")]
    public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}

public record UpdateTodoItemCommand(int Id, string? Title, bool Done) : IRequest;

public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class UpdateTodoItemCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ApplicationDbContext _context = context;

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException(nameof(TodoItem), request.Id);

        todoItem.Title = request.Title;
        todoItem.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);
    }
}