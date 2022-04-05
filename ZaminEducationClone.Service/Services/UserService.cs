using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Users;
using ZaminEducationClone.Service.DTOs;
using ZaminEducationClone.Service.Extensions;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public async Task<BaseResponse<User>> LogIn(LogIn login)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();

            var user = await unitOfWork.Users.GetAsync(obj => obj.Password == login.Password && obj.Email == login.Email);
            if (user == null || user.Status == Domain.Enums.ItemState.Deleted)
            {
                baseResponse.Error = new ErrorModel(400, "Email or Password is incorrect");
                return baseResponse;
            }

            baseResponse.Data = user;
            return baseResponse;
        }

        public async Task<BaseResponse<User>> CreateAsync(UserCreateDto userDTo)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();
            var entity = await unitOfWork.Users.GetAsync(obj => obj.Login == userDTo.Login);

            if (entity is not null)
            {
                baseResponse.Error = new ErrorModel(400, "User is exist");
                return baseResponse;
            }

            var user = mapper.Map<User>(userDTo);
            user.Create("1");


            var result = await unitOfWork.Users.CreateAsync(user);
            await unitOfWork.SaveChangesAsync();
            baseResponse.Data = result;

            return baseResponse;
        }

        public async Task<BaseResponse<User>> UpdateAsync(UserUpdateDto userDto)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();

            var entity = await unitOfWork.Users.GetAsync(obj => obj.Id == userDto.Id);
            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            var user = mapper.Map<User>(userDto);
            user.Update("1");
            user.Id = userDto.Id;


            var result = await unitOfWork.Users.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = result;
            return baseResponse;
        }

        public async Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            BaseResponse<User> baseResponse = new BaseResponse<User>();

            var entity = await unitOfWork.Users.GetAsync(expression);
            if (entity is null || entity.Status == Domain.Enums.ItemState.Deleted)
            {
                baseResponse.Error = new ErrorModel(404, "Customer not found");
                return baseResponse;
            }

            baseResponse.Data = entity;
            return baseResponse;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            BaseResponse<bool> baseResponse = new BaseResponse<bool>();
            var entity = await unitOfWork.Users.GetAsync(expression);

            if (entity is null)
            {
                baseResponse.Error = new ErrorModel(400, "User not found");
                return baseResponse;
            }

            entity.Status = Domain.Enums.ItemState.Deleted;
            await unitOfWork.SaveChangesAsync();

            baseResponse.Data = true;
            return baseResponse;

        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            BaseResponse<IEnumerable<User>> baseResponse = new BaseResponse<IEnumerable<User>>();

            var entities = await unitOfWork.Users.GetAllAsync(expression);
            if (entities is null)
            {
                baseResponse.Error = new ErrorModel(400, "Users not found");
                return baseResponse;
            }


            baseResponse.Data = entities.Where(obj => obj.Status != Domain.Enums.ItemState.Deleted).ToPagedList(@params);

            return baseResponse;
        }

    }
}
