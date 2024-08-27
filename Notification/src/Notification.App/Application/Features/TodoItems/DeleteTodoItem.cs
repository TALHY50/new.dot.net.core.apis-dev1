using MediatR;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Exceptions;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Notification.Domain.Entities.Todos;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

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