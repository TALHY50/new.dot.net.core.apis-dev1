using SharedKernel.Main.Notification.Domain.Entities.Todos;

namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}