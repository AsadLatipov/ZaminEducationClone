using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface ICourseRepository
    {
        Task<Course> CreateAsync(Course entity);
        Task<Course> GetAsync(Expression<Func<Course, bool>> expression);
        Task<IQueryable<Course>> GetAllAsync(Expression<Func<Course, bool>> expression = null);
        Task<Course> UpdateAsync(Course entity);
        Task<bool> DeleteAsync(Expression<Func<Course, bool>> expression);
    }
}
