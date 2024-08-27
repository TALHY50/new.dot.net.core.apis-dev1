using MediatR;

using SharedKernel.Main.Application.Common.Models;
using SharedKernel.Main.Notification.Domain.Entities.Todos;

namespace Notification.App.Application.Features.TodoItems.EventHandlers;

internal sealed class TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) : INotificationHandler<DomainEventNotification<TodoItemCompletedEvent>>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger = logger;

    public Task Handle(DomainEventNotification<TodoItemCompletedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("VerticalSlice Entities Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}