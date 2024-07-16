using Notification.App.Application.Common;

namespace Notification.Main.Domain.Todos;

internal sealed class TodoItemDeletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}