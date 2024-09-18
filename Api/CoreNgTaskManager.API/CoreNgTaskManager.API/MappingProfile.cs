using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace CoreNgTaskManager.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));

            CreateMap<TaskItemForCreationDto, TaskItem>();
            CreateMap<TaskItemForUpdateDto, TaskItem>().ReverseMap();

            CreateMap<UserForRegistrationDto, ApplicationUser>();
        }
    }
}
