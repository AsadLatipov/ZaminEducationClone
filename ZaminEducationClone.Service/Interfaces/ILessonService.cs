using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Service.Interfaces
{
    public interface ILessonService
    {
        //Task<BaseResponse<Lesson>> CreateAsync(SectionCreateDto sectionDto);
        //Task<BaseResponse<Lesson>> UpdateAsync(SectionUpdateDto sectionDto);
        Task<BaseResponse<Lesson>> GetAsync(Expression<Func<Lesson, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Lesson, bool>> expression);
        Task<BaseResponse<IEnumerable<Section>>> GetAllAsync(PaginationParams @params, Expression<Func<Lesson, bool>> expression = null);
    }
}
