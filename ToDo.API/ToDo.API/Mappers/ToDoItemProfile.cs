using AutoMapper;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Mappers
{
    public class ToDoItemProfile: Profile
    {
        public ToDoItemProfile()
        {
            CreateMap<ToDoItem, ToDoItemGetDto>();
            
            CreateMap<ToDoItemPostDto, ToDoItem>()
                .ForMember(item => item.CreatedDate, option => option.MapFrom(s => DateTime.UtcNow))
                .ForMember(item => item.Id, option => option.MapFrom(s => Guid.NewGuid()));
        }
    }
}
