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
        Task<BaseResponse<User>> LogIn(LogIn login);
        Task<BaseResponse<User>> UpdateAsync(UserUpdateDto userDTo);
        Task<BaseResponse<User>> CreateAsync(UserCreateDto userDTo);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<IEnumerable<User>>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null);

    }
}
