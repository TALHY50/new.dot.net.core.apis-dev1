using SharedKernel.Main.Application.Common.Common;

namespace SharedKernel.Main.Domain.Notification.Todos;

public sealed class TodoItemCompletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}