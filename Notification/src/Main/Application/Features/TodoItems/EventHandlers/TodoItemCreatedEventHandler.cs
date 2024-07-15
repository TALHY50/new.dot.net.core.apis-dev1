using MediatR;

using Microsoft.Extensions.Logging;

using Notification.Main.Application.Common.Models;
using Notification.Main.Domain.Todos;

namespace Notification.Main.Application.Features.TodoItems.EventHandlers;

internal sealed class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger = logger;

    public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("VerticalSlice Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}