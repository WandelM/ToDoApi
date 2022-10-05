using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private IList<ToDoItem> _items;

        public ToDoItemsRepository()
        {
            _items = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                    Id = Guid.Parse("e7bd292e-405d-4845-98e6-007aa08eef98"),
                    UserId = Guid.Parse("7dcbd5f3-a61e-48de-8830-33cfcc570da0"),
                    Name = "Mock Item 1",
                    CreatedDate = DateTime.Now,
                    Description = "This is simple description 1",
                    DueDate = DateTime.Now.AddYears(2)
                },
                new ToDoItem()
                {
                    Id = Guid.Parse("b4960efd-00a1-4a80-834e-ba307f0e1592"),
                    UserId = Guid.Parse("7dcbd5f3-a61e-48de-8830-33cfcc570da0"),
                    Name = "Mock Item 2",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    Description = "This is simple description 2",
                    DueDate = DateTime.Now.AddYears(2)
                },
                new ToDoItem()
                {
                    Id = Guid.Parse("a6960efd-00a1-4a80-834e-ba307f0e1592"),
                    UserId = Guid.Parse("7dcbd5f3-a61e-48de-8830-33cfcc570da0"),
                    Name = "Mock Item 3",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    Description = "This is simple description 3",
                    DueDate = DateTime.Now.AddYears(2)
                }
            };
        }

        public async Task<ToDoItem?> GetById(Guid userId, Guid itemId)
        {
            var item = _items.FirstOrDefault(x => x.Id == itemId && x.UserId == userId);

            await Task.CompletedTask;
            return item;
        }

        public async Task<IReadOnlyList<ToDoItem>> GetAll(Guid userId)
        {
            await Task.CompletedTask;
            return _items.Where(i => i.UserId == userId).ToList();
        }

        public async Task CreateItemAsync(ToDoItem toDoItem)
        {
            _items.Add(toDoItem);
            await Task.CompletedTask;
        }
    }
}
