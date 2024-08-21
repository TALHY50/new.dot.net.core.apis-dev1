using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.Domain.Todos;

internal sealed class TodoItemDeletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}