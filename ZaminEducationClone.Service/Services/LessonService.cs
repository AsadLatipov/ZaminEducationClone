using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.LessonDto;
using ZaminEducationClone.Service.Extensions;
using ZaminEducationClone.Service.Helpers;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Service.Services
{
    public class LessonService : ILessonService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public LessonService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.env = env;
        }

        public async Task<BaseResponse<Lesson>> CreateAsync(LessonCreateDto lessonDto)
        {
            BaseResponse<Lesson> baseResponse = new BaseResponse<Lesson>();
            var entity = await unitOfWork.Lessons.GetAsync(obj => obj.Title == lessonDto.Title);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Lesson is exist");
                return baseResponse;
            }

            var lesson = mapper.Map<Lesson>(lessonDto);
            lesson.Create("1");

            string hostUrl = AccesToContext.Context?.Request?.Scheme + "://" + AccesToContext.Context?.Request?.Host.Value + "/";

            var fileName = await SaveFileAsync(lessonDto);
            lesson.VideoUrl = hostUrl + configuration.GetSection("Storage:VideoUrl").Value + fileName;

            var result = await unitOfWork.Lessons.CreateAsync(lesson);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;

            return baseResponse;
        }

        public async Task<BaseResponse<Lesson>> UpdateAsync(LessonUpdateDto lessonDto)
        {
            BaseResponse<Lesson> baseResponse = new BaseResponse<Lesson>();

            var entity = await unitOfWork.Lessons.GetAsync(obj => obj.Id == lessonDto.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Lesson not found");
                return baseResponse;
            }

            var lesson = mapper.Map<Lesson>(lessonDto);
            lesson.Update("1");
            lesson.Id = lessonDto.Id;


            var result = await unitOfWork.Lessons.UpdateAsync(lesson);
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Lesson>> GetAsync(Expression<Func<Lesson, bool>> expression)
        {
            BaseResponse<Lesson> baseResponse = new BaseResponse<Lesson>();


            var entity = await unitOfWork.Lessons.GetAsync(expression);
            if (entity is null || entity.Status == Domain.Enums.ItemState.Deleted)
            {
                baseResponse.Error = new ErrorModel(404, "Lesson not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Lesson, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Lessons.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Lesson not found");
                return baseResponse;
            }

            entity.Status = Domain.Enums.ItemState.Deleted;
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;
        }

        public async Task<BaseResponse<IEnumerable<Lesson>>> GetAllAsync(PaginationParams @params, Expression<Func<Lesson, bool>> expression = null)
        {
            BaseResponse<IEnumerable<Lesson>> baseResponse = new BaseResponse<IEnumerable<Lesson>>();

            var entities = await unitOfWork.Lessons.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Lesson not found");
                return baseResponse;
            }


            baseResponse.Data = entities.Where(obj => obj.Status != Domain.Enums.ItemState.Deleted).ToPagedList(@params);

            return baseResponse;
        }



        public async Task<string> SaveFileAsync(LessonCreateDto lesson)
        {
            string fileName = Guid.NewGuid().ToString("N") + "_" + lesson.VideoUrl.FileName;
            string storagePath = configuration.GetSection("Storage:imageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream file = File.Create(filePath);
            await lesson.VideoUrl.OpenReadStream().CopyToAsync(file);
            file.Close();
            return fileName;
        }

    }
}
