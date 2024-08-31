using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Domain.Entities.Todos;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Exceptions;

namespace Notification.App.Application.Features.TodoItems;

public class UpdateTodoItemDetailController : ApiControllerBase
{
    [HttpPut("/api/todo-items/[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}

public record UpdateTodoItemDetailCommand(int Id, int ListId, PriorityLevel Priority, string? Note) : IRequest;

public class UpdateTodoItemDetailCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly ApplicationDbContext _context = context;

    public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException(nameof(TodoItem), request.Id);

        todoItem.ListId = request.ListId;
        todoItem.Priority = request.Priority;
        todoItem.Note = request.Note;

        await _context.SaveChangesAsync(cancellationToken);
    }
}