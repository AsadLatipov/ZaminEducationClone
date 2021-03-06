using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface ITopicRepository
    {
        Task<Topic> CreateAsync(Topic entity);
        Task<Topic> GetAsync(Expression<Func<Topic, bool>> expression, List<string> include = null);
        Task<IQueryable<Topic>> GetAllAsync(Expression<Func<Topic, bool>> expression = null);
        Task<Topic> UpdateAsync(Topic entity);
        Task<bool> DeleteAsync(Expression<Func<Topic, bool>> expression);
    }
}
