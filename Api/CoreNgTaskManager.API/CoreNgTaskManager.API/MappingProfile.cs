using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace CoreNgTaskManager.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemForCreationDto, TaskItem>();
            CreateMap<TaskItemForUpdateDto, TaskItem>().ReverseMap();

            CreateMap<UserForRegistrationDto, ApplicationUser>();
        }
    }
}
