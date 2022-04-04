using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.CourseDto;
using ZaminEducationClone.Service.Extensions;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;

        public CourseService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.env = env;
            this.configuration = configuration;
        }

        public async Task<BaseResponse<Course>> CreateAsync(CourseCreateDto courseDto)
        {
            BaseResponse<Course> baseResponse = new BaseResponse<Course>();
            var entity = await unitOfWork.Sections.GetAsync(obj => obj.Name == courseDto.Name);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Course is exist");
                return baseResponse;
            }

            var course = mapper.Map<Course>(courseDto);
            course.Create("1");


            var result = await unitOfWork.Courses.CreateAsync(course);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;

            return baseResponse;
        }

        public async Task<BaseResponse<Course>> UpdateAsync(CourseUpdateDto courseDto)
        {
            BaseResponse<Course> baseResponse = new BaseResponse<Course>();

            var entity = await unitOfWork.Users.GetAsync(obj => obj.Id == courseDto.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Course not found");
                return baseResponse;
            }

            var course = mapper.Map<Course>(courseDto);
            course.Update("1");
            course.Id = courseDto.Id;


            var result = await unitOfWork.Courses.UpdateAsync(course);
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression)
        {
            BaseResponse<Course> baseResponse = new BaseResponse<Course>();

            List<string> lst = new List<string>() { "Topics" };

            var entity = await unitOfWork.Courses.GetAsync(expression, lst);
            if (entity is null || entity.Status == Domain.Enums.ItemState.Deleted)
            {
                baseResponse.Error = new ErrorModel(404, "Course not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }
        
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Courses.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Course not found");
                return baseResponse;
            }

            entity.Status = Domain.Enums.ItemState.Deleted;
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;
        }

        public async Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            BaseResponse<IEnumerable<Course>> baseResponse = new BaseResponse<IEnumerable<Course>>();

            var entities = await unitOfWork.Courses.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Course not found");
                return baseResponse;
            }


            baseResponse.Data = entities.Where(obj => obj.Status != Domain.Enums.ItemState.Deleted).ToPagedList(@params);

            return baseResponse;
        }

        public async Task<string> SaveFileAsync(CourseCreateDto course)
        {
            string fileName = Guid.NewGuid().ToString("N") + "_" + course.Image.FileName;
            string storagePath = configuration.GetSection("Storage:imageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream file = File.Create(filePath);
            await course.Image.OpenReadStream().CopyToAsync(file);
            file.Close();
            return fileName;
        }

    }
}
