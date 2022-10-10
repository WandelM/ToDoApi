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

            CreateMap<UserPostDto, UserModel>()
                .ForMember(u => u.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(u => u.CreatedDate, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
