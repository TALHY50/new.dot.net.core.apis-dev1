using MediatR;

using Notification.App.Domain.Entities.Todos;

using SharedKernel.Main.Application.Common.Models;

namespace Notification.App.Application.Features.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) : INotificationHandler<DomainEventNotification<TodoItemCompletedEvent>>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger = logger;

    public Task Handle(DomainEventNotification<TodoItemCompletedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("VerticalSlice Entities Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}