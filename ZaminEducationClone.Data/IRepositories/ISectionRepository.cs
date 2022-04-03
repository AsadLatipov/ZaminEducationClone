using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface ISectionRepository
    {
        Task<Section> CreateAsync(Section entity);
        Task<Section> GetAsync(Expression<Func<Section, bool>> expression);
        Task<IQueryable<Section>> GetAllAsync(Expression<Func<Section, bool>> expression = null);
        Task<Section> UpdateAsync(Section entity);
        Task<bool> DeleteAsync(Expression<Func<Section, bool>> expression);
    }
}
