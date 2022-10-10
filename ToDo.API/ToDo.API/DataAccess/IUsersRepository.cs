using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public interface IUsersRepository
    {
        Task AddAsync(UserModel userModel);
        Task<UserModel?> GetAsync(Guid id);
        Task<UserModel?> GetByNameAsync(string name);
        Task UpdateAsync(UserModel userModel);
        Task DeleteAsync(Guid id);
    }
}
