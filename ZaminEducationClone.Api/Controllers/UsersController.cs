using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Users;
using ZaminEducationClone.Service.DTOs;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usersController : ControllerBase
    {
        private readonly IUserService userService;
        public usersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<User>>> LogIn(LogIn logIn)
        {
            var result = await userService.LogIn(logIn);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }


        [HttpPost("sign-up")]
        public async Task<ActionResult<BaseResponse<User>>> SignUP([FromRoute(Name = "sign-up")]UserCreateDto useDto)
        {
            var result = await userService.CreateAsync(useDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<User>>> UpdateUser(UserUpdateDto user)
        {
            var result = await userService.UpdateAsync(user);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<User>>> GetUser(Guid id)
        {
            var result = await userService.GetAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteUser(Guid id)
        {
            var result = await userService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<User>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await userService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

    }
}
