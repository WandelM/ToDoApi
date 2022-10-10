using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public interface IToDoItemsRepository
    {
        Task<IReadOnlyList<ToDoItem>> GetAllAsync(Guid userId);
        Task<ToDoItem?> GetByIdAsync(Guid userId, Guid itemId);
        Task CreateItemAsync(ToDoItem toDoItem);
    }
}