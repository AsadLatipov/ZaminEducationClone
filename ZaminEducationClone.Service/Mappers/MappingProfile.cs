using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
