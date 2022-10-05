using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public interface IToDoItemsRepository
    {
        Task<IReadOnlyList<ToDoItem>> GetAll(Guid userId);
        Task<ToDoItem?> GetById(Guid userId, Guid itemId);
        Task CreateItemAsync(ToDoItem toDoItem);
    }
}