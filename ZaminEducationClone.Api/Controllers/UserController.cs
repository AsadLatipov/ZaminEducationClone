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
    [Route("[controller]")]
    public class userController : ControllerBase
    {
        private readonly IUserService userService;

        [HttpPost]
        public async Task<ActionResult<BaseResponse<User>>> SignUP(UserCreateDTo useDto)
        {
            var result = await userService.CreateAsync(useDto);

            return result.Error.Code == null ? NotFound(result) : Ok(result);
        }

        [HttpGet("{user-id}")]
        public async Task<ActionResult<BaseResponse<User>>> GetUser([FromForm(Name = "user-id")] Guid id)
        {
            var result = await userService.GetAsync(obj => obj.Id == id);
            
            return result.Error.Code == null ? NotFound(result) : Ok(result);
        }
        
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<User>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await userService.GetAllAsync(@params);
            
            return result.Error.Code == null ? NotFound(result) : Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<User>>> UpdateUser(User user)
        {
            var result = await userService.UpdateAsync(user);
            
            return result.Error.Code == null ? NotFound(result) : Ok(result);
        }

        [HttpDelete("{user-id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteUser([FromRoute(Name = "user-id")] Guid id)
        {
            var result = await userService.DeleteAsync(obj => obj.Id == id);

            return result.Error.Code == null ? NotFound(result) : Ok(result);
        }


    }
}
