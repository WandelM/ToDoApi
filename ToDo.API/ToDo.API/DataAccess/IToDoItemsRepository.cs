using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public interface IToDoItemsRepository
    {
        Task<IReadOnlyList<ToDoItem>> GetAll();
        Task<ToDoItem?> GetById(Guid id);
        Task CreateItemAsync(ToDoItem toDoItem);
    }
}