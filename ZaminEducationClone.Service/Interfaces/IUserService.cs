using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Users;
using ZaminEducationClone.Service.DTOs;

namespace ZaminEducationClone.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> CreateAsync(UserCreateDTo userDTo);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<IEnumerable<User>>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null);
        Task<BaseResponse<User>> UpdateAsync(UserUpdateDTo userDTo);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
