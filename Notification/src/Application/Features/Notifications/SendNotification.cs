using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.Application.Common;
using Notification.Application.Domain.Todos;
using Notification.Application.Infrastructure.Persistence;

namespace Notification.Application.Features.TodoItems;

public class SendNotificationController : ApiControllerBase
{
    [HttpPost("/api/notification/send")]
    public async Task<ActionResult<int>> Create(SendNotificationCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record SendNotificationCommand(int ListId, string? Title) : IRequest<int>;

internal sealed class SendNotificationCommandValidator : AbstractValidator<SendNotificationCommand>
{
    public SendNotificationCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class SendNotificationCommandHandler(ApplicationDbContext context) : IRequestHandler<SendNotificationCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
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