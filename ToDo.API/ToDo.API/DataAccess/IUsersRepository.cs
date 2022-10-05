using ToDo.API.Models;

namespace ToDo.API.DataAccess
{
    public interface IUsersRepository
    {
        public void Add(UserModel userModel);
        public UserModel? Get(Guid id);
        public void Update(UserModel userModel);
        public void Delete(Guid id);
    }
}
