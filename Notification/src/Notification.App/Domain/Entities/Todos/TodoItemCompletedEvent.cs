using SharedKernel.Main.Application.Common;

namespace Notification.App.Domain.Entities.Todos;

public sealed class TodoItemCompletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}