using Microsoft.EntityFrameworkCore;
using ToDo.API.DbContexts;
using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private readonly DbSet<ToDoItem> _toDoItems;
        private readonly ToDoApiContext _dbContext;

        public ToDoItemsRepository(ToDoApiContext toDoApiContext)
        {
            _dbContext = toDoApiContext;
            _toDoItems = toDoApiContext.Set<ToDoItem>();
        }

        public async Task<ToDoItem?> GetByIdAsync(Guid userId, Guid itemId)
        {
            var item = await _toDoItems.FirstOrDefaultAsync(x => x.Id == itemId && x.UserId == userId);
            return item;
        }

        public async Task<IReadOnlyList<ToDoItem>> GetAllAsync(Guid userId)
        {
            var items = _toDoItems.Where(i => i.UserId == userId);
            return await items.ToListAsync();
        }

        public async Task CreateItemAsync(ToDoItem toDoItem)
        {
            if (toDoItem == null) throw new NullReferenceException(nameof(toDoItem));

            await _toDoItems.AddAsync(toDoItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
