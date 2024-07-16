using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Common;
using Notification.App.Application.Common.Exceptions;
using Notification.Main.Domain.Todos;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.App.Application.Features.TodoItems;

public class DeleteTodoItemController : ApiControllerBase
{
    [HttpDelete("/api/todo-items/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}

public record DeleteTodoItemCommand(int Id) : IRequest;

internal sealed class DeleteTodoItemCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ApplicationDbContext _context = context;

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException(nameof(TodoItem), request.Id);
        _context.TodoItems.Remove(entity);

        entity.DomainEvents.Add(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}