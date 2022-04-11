using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.SectionDto;
using ZaminEducationClone.Service.Extensions;
using ZaminEducationClone.Service.Helpers;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Service.Services
{
    public class SectionService : ISectionService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SectionService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Section>> CreateAsync(SectionCreateDto sectionDto)
        {
            BaseResponse<Section> baseResponse = new BaseResponse<Section>();
            var entity = await unitOfWork.Sections.GetAsync(obj => obj.NameUz == sectionDto.NameUz);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Section is exist");
                return baseResponse;
            }

            var section = mapper.Map<Section>(sectionDto);
            section.Create("1");


            var result = await unitOfWork.Sections.CreateAsync(section);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;

            return baseResponse;
        }

        public async Task<BaseResponse<Section>> UpdateAsync(SectionUpdateDto sectionDto)
        {
            BaseResponse<Section> baseResponse = new BaseResponse<Section>();

            var entity = await unitOfWork.Users.GetAsync(obj => obj.Id == sectionDto.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Section not found");
                return baseResponse;
            }

            var section = mapper.Map<Section>(sectionDto);
            section.Update("1");
            section.Id = sectionDto.Id;


            var result = await unitOfWork.Sections.UpdateAsync(section);
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Section, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Sections.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Section not found");
                return baseResponse;
            }

            entity.Status = Domain.Enums.ItemState.Deleted;
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;
        }

        public async Task<BaseResponse<Section>> GetAsync(Expression<Func<Section, bool>> expression)
        {
            BaseResponse<Section> baseResponse = new BaseResponse<Section>();

            List<string> lst = new List<string>() { "Courses.Topics.Lessons" };

            var entity = await unitOfWork.Sections.GetAsync(expression, lst);
            if (entity is null || entity.Status == Domain.Enums.ItemState.Deleted)
            {
                baseResponse.Error = new ErrorModel(404, "Section not found");
                return baseResponse;
            }

            string lang = AccesToContext.Language;
            entity.Name =  lang == "en" ? entity.NameEng : lang == "ru" ? entity.NameRu : entity.NameUz;
            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<IEnumerable<Section>>> GetAllAsync(PaginationParams @params, Expression<Func<Section, bool>> expression = null)
        {
            BaseResponse<IEnumerable<Section>> baseResponse = new BaseResponse<IEnumerable<Section>>();

            var entities = await unitOfWork.Sections.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Section not found");
                return baseResponse;
            }


            baseResponse.Data = entities.Where(obj => obj.Status != Domain.Enums.ItemState.Deleted).ToPagedList(@params);

            return baseResponse;
        }

    }
}
