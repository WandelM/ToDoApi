using ToDo.API.DataAccess;
using ToDo.API.Models;

public class UsersRepository : IUsersRepository
{
    private readonly List<UserModel> _users;

    public UsersRepository()
    {
        _users = new List<UserModel>
        {
            new UserModel() {
                Id = Guid.Parse("7dcbd5f3-a61e-48de-8830-33cfcc570da0"),
                CreatedDate = DateTime.Now,
                LastLogIn = DateTime.Now,
                Password = "Secret1",
                UserName = "secretuser1@temp.com"
            },
            new UserModel() {
                Id = Guid.Parse("3f36e6d9-4789-40d5-96bd-58a3a0575de6"),
                CreatedDate = DateTime.Now,
                LastLogIn = DateTime.Now,
                Password = "Secret2",
                UserName = "secretuser2@temp.com"
            }
        };
    }

    public void Add(UserModel userModel)
    {
        var userExists = _users.Any(u => u.Id == userModel.Id);
        
        if (userExists)
            return;

        _users.Add(userModel);
    }

    public void Delete(Guid id)
    {
        var toRemove = _users.FirstOrDefault(u => u.Id == id);

        if (toRemove == null)
            return;

        _users.Remove(toRemove);
    }

    public UserModel? Get(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id.Equals(id));
    }

    public void Update(UserModel userModel)
    {
        var toUpdate = _users.FirstOrDefault(u => u.Id == userModel.Id);

        if (toUpdate == null)
            return;

        toUpdate.Password = userModel.Password;
        toUpdate.UserName = userModel.UserName;
    }
}
