using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Notification.Application.Common;
using Notification.Application.Common.Exceptions;
using Notification.Application.Domain.Todos;
using Notification.Application.Infrastructure.Persistence;

namespace Notification.Application.Features.TodoLists;

public class DeleteTodoListController : ApiControllerBase
{
    [HttpDelete("/api/todo-lists/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoListCommand(id));

        return NoContent();
    }
}

public record DeleteTodoListCommand(int Id) : IRequest;

internal sealed class DeleteTodoListCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteTodoListCommand>
{
    private readonly ApplicationDbContext _context = context;

    public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var todoList = await _context.TodoLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(TodoList), request.Id);

        _context.TodoLists.Remove(todoList);

        await _context.SaveChangesAsync(cancellationToken);
    }
}