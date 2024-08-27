using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.Notification.Domain.Entities.Todos;

public sealed class TodoItemCreatedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}