using Microsoft.EntityFrameworkCore;
using ToDo.API.DataAccess;
using ToDo.API.DbContexts;
using ToDo.API.Models;

public class UsersRepository : IUsersRepository
{
    private readonly ToDoApiContext _toDoApiContext;
    private DbSet<UserModel> Users => _toDoApiContext.Set<UserModel>();

    public UsersRepository(ToDoApiContext toDoApiContext)
    {
        _toDoApiContext = toDoApiContext ?? throw new NullReferenceException(nameof(toDoApiContext));
    }

    public async Task AddAsync(UserModel userModel)
    {
        var userExists = await Users.AnyAsync(u => u.Id == userModel.Id);
        
        if (userExists)
            return;

        await Users.AddAsync(userModel);
        await _toDoApiContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var toRemove = Users.FirstOrDefault(u => u.Id == id);

        if (toRemove == null)
            return;

        Users.Remove(toRemove);
        await _toDoApiContext.SaveChangesAsync();
    }

    public async Task<UserModel?> GetAsync(Guid id)
    {
        return await Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
    }

    public async Task UpdateAsync(UserModel userModel)
    {
        var toUpdate = await Users.FirstOrDefaultAsync(u => u.Id == userModel.Id);

        if (toUpdate == null)
            return;

        toUpdate.Password = userModel.Password;
        toUpdate.UserName = userModel.UserName;
        await _toDoApiContext.SaveChangesAsync();
    }

    public async Task<UserModel?> GetByNameAsync(string name)
    {
        return await _toDoApiContext.Set<UserModel>().FirstOrDefaultAsync(u => u.UserName == name);
    }
}
