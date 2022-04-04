using AutoMapper;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Domain.Entities.Users;
using ZaminEducationClone.Service.DTOs;
using ZaminEducationClone.Service.DTOs.CourseDto;
using ZaminEducationClone.Service.DTOs.LessonDto;
using ZaminEducationClone.Service.DTOs.SectionDto;
using ZaminEducationClone.Service.DTOs.TopicDto;

namespace ZaminEducationClone.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            
            CreateMap<SectionCreateDto, Section>().ReverseMap();
            CreateMap<SectionUpdateDto, Section>().ReverseMap();
            
            CreateMap<TopicCreateDto, Topic>().ReverseMap();
            CreateMap<TopicUpdateDto, Topic>().ReverseMap();

            CreateMap<CourseCreateDto, Course>().ReverseMap();
            CreateMap<CourseUpdateDto, Course>().ReverseMap();

            CreateMap<LessonCreateDto, Lesson>().ReverseMap();
            CreateMap<LessonUpdateDto, Lesson>().ReverseMap();



        }
    }
}
