using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace CoreNgTaskManager.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, ApplicationUser>();
   
        }
    }
}
