using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.TopicDto;
using ZaminEducationClone.Service.Extensions;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Service.Services
{
    public class TopicService : ITopicService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public TopicService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Topic>> CreateAsync(TopicCreateDto topicDto)
        {
            BaseResponse<Topic> baseResponse = new BaseResponse<Topic>();
            var entity = await unitOfWork.Topics.GetAsync(obj => obj.Name == topicDto.Name);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "Topic is exist");
                return baseResponse;
            }

            var topic = mapper.Map<Topic>(topicDto);
            topic.Create("1");


            var result = await unitOfWork.Topics.CreateAsync(topic);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;

            return baseResponse;
        }

        public async Task<BaseResponse<Topic>> UpdateAsync(TopicUpdateDto topicDto)
        {
            BaseResponse<Topic> baseResponse = new BaseResponse<Topic>();

            var entity = await unitOfWork.Users.GetAsync(obj => obj.Id == topicDto.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Topic not found");
                return baseResponse;
            }

            var topic = mapper.Map<Topic>(topicDto);
            topic.Update("1");
            topic.Id = topicDto.Id;


            var result = await unitOfWork.Topics.UpdateAsync(topic);
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<Topic>> GetAsync(Expression<Func<Topic, bool>> expression)
        {
            BaseResponse<Topic> baseResponse = new BaseResponse<Topic>();

            List<string> lst = new List<string>() { "Lessons" };

            var entity = await unitOfWork.Topics.GetAsync(expression, lst);
            if (entity is null || entity.Status == Domain.Enums.ItemState.Deleted)
            {
                baseResponse.Error = new ErrorModel(404, "Topic not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }
        
        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Topic, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Topics.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "Topic not found");
                return baseResponse;
            }

            entity.Status = Domain.Enums.ItemState.Deleted;
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;
        }

        public async Task<BaseResponse<IEnumerable<Topic>>> GetAllAsync(PaginationParams @params, Expression<Func<Topic, bool>> expression = null)
        {
            BaseResponse<IEnumerable<Topic>> baseResponse = new BaseResponse<IEnumerable<Topic>>();

            var entities = await unitOfWork.Topics.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Topic not found");
                return baseResponse;
            }


            baseResponse.Data = entities.Where(obj => obj.Status != Domain.Enums.ItemState.Deleted).ToPagedList(@params);

            return baseResponse;
        }

    }
}
