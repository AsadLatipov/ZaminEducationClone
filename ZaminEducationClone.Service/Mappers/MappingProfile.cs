using AutoMapper;
using ZaminEducationClone.Domain.Entities.Users;
using ZaminEducationClone.Service.DTOs;

namespace ZaminEducationClone.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDTo, User>().ReverseMap();
        }
    }
}
