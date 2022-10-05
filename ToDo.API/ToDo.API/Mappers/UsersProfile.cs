using AutoMapper;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Mappers
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<UserModel, UserGetDto>();

        }
    }
}
