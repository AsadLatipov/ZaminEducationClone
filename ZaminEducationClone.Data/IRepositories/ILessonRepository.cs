using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface ILessonRepository
    {
        Task<Lesson> CreateAsync(Lesson entity);
        Task<Lesson> GetAsync(Expression<Func<Lesson, bool>> expression, List<string> include = null);
        Task<IQueryable<Lesson>> GetAllAsync(Expression<Func<Lesson, bool>> expression = null);
        Task<Lesson> UpdateAsync(Lesson entity);
        Task<bool> DeleteAsync(Expression<Func<Lesson, bool>> expression);
    }
}
