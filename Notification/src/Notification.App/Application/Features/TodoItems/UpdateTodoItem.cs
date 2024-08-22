using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Exceptions;
using SharedKernel.Main.Domain.Notification.Todos;
using SharedKernel.Main.Infrastructure.Persistence;

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

internal sealed class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class UpdateTodoItemCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateTodoItemCommand>
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