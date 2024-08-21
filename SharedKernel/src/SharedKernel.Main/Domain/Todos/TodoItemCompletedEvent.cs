using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.Domain.Todos;

public class TodoItemCompletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}