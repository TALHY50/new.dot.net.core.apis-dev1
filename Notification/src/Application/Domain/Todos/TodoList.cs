using Notification.Application.Common;
using Notification.Application.Domain.ValueObjects;

namespace Notification.Application.Domain.Todos;

public class TodoList : AuditableEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}