using MediatR;

using SharedKernel.Main.Application.Common.Models;
using SharedKernel.Main.Notification.Domain.Entities.Todos;

namespace Notification.App.Application.Features.TodoItems.EventHandlers;

internal sealed class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger = logger;

    public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("VerticalSlice Entities Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}