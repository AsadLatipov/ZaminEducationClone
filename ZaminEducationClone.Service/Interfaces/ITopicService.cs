using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.TopicDto;

namespace ZaminEducationClone.Service.Interfaces
{
    public interface ITopicService
    {
        Task<BaseResponse<Topic>> CreateAsync(TopicCreateDto sectionDto);
        Task<BaseResponse<Topic>> UpdateAsync(TopicUpdateDto sectionDto);
        Task<BaseResponse<Topic>> GetAsync(Expression<Func<Topic, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Topic, bool>> expression);
        Task<BaseResponse<IEnumerable<Topic>>> GetAllAsync(PaginationParams @params, Expression<Func<Topic, bool>> expression = null);
    }
}
