using backend.Application.TodoLists.Queries.ExportTodos;

namespace backend.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
