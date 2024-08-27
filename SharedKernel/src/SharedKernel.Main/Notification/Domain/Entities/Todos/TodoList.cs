using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Notification.Domain.Entities.ValueObjects;

namespace SharedKernel.Main.Notification.Domain.Entities.Todos;

public class TodoList : AuditableEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}