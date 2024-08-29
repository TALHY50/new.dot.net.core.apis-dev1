using SharedKernel.Main.Application.Common;

namespace Notification.App.Domain.Entities.Todos;

public sealed class TodoItemDeletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}