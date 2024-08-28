using Notification.App.Domain.Entities.Todos;

namespace Notification.App.Application.Interfaces.Services;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}