using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Domain.Entities.Todos;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Exceptions;

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

public class DeleteTodoItemCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteTodoItemCommand>
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