using Notification.App.Application.Common;

namespace Notification.App.Domain.Todos;

internal sealed class TodoItemCreatedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}