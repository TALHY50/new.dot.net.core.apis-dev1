﻿using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.Application.Common;
using Notification.Application.Domain.Todos;
using Notification.Application.Infrastructure.Persistence;

namespace Notification.Application.Features.TodoItems;

public class CreateTodoItemController : ApiControllerBase
{
    [HttpPost("/api/create-outgoing")]
    public async Task<ActionResult<int>> Create(CreateOutgoingCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateOutgoingCommand(int ListId, string? Title) : IRequest<int>;

internal sealed class CreateTodoItemCommandValidator : AbstractValidator<CreateOutgoingCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

internal sealed class CreateToDoItemCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateOutgoingCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(CreateOutgoingCommand request, CancellationToken cancellationToken)
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