using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.CourseDto;

namespace ZaminEducationClone.Service.Interfaces
{
    public interface ICourseService
    {
        Task<BaseResponse<Course>> CreateAsync(CourseCreateDto sectionDto);
        Task<BaseResponse<Course>> UpdateAsync(CourseUpdateDto sectionDto);
        Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression);
        Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
        Task<string> SaveFileAsync(CourseCreateDto course);
    }
}
