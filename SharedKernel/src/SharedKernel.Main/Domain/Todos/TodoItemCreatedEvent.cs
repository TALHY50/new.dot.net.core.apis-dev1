using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.Domain.Todos;

internal sealed class TodoItemCreatedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}