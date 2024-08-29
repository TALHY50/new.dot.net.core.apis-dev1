using Notification.App.Domain.Entities.ValueObjects;

using SharedKernel.Main.Application.Common;

namespace Notification.App.Domain.Entities.Todos;

public class TodoList : AuditableEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}