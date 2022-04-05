using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.LessonDto;

namespace ZaminEducationClone.Service.Interfaces
{
    public interface ILessonService
    {
        Task<BaseResponse<Lesson>> CreateAsync(LessonCreateDto sectionDto);
        Task<BaseResponse<Lesson>> UpdateAsync(LessonUpdateDto sectionDto);
        Task<BaseResponse<Lesson>> GetAsync(Expression<Func<Lesson, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Lesson, bool>> expression);
        Task<BaseResponse<IEnumerable<Lesson>>> GetAllAsync(PaginationParams @params, Expression<Func<Lesson, bool>> expression = null);
        Task<string> SaveFileAsync(LessonCreateDto lesson);


    }

}
