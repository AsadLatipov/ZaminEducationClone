﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Entities.Users;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
