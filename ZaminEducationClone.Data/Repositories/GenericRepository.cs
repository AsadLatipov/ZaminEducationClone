using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;

namespace ZaminEducationClone.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
#pragma warning disable
        internal ZaminEducationContext dbcontext;
        internal DbSet<T> dbset;
        public GenericRepository(ZaminEducationContext dbcontext)
        {
            this.dbcontext = dbcontext;
            this.dbset = dbcontext.Set<T>();
        }


        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbset.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = dbset.Update(entity);
            return entry.Entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> include = null)
        {
            IQueryable<T> query = dbset;
            
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            
            var entity = await query.AsNoTracking().FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbset.FirstOrDefaultAsync(expression);

            if (entity is null) return false;

            dbset.Remove(entity);
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? dbset : dbset.Where(expression);

        }
    }
}
