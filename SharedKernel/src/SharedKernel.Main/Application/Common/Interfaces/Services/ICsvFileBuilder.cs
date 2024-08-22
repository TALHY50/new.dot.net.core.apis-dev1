using SharedKernel.Main.Domain.Notification.Todos;

namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}