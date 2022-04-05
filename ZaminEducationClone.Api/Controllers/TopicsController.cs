using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.TopicDto;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class topicsController : ControllerBase
    {
        private readonly ITopicService topicService;
        public topicsController(ITopicService topicService)
        {
            this.topicService = topicService;
        }



        [HttpPost]
        public async Task<ActionResult<BaseResponse<Topic>>> CreateAsync(TopicCreateDto topicDto)
        {
            var result = await topicService.CreateAsync(topicDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<Topic>>> UpdateASync(TopicUpdateDto section)
        {
            var result = await topicService.UpdateAsync(section);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Topic>>> GetAsync(Guid id)
        {
            var result = await topicService.GetAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync(Guid id)
        {
            var result = await topicService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Topic>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await topicService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
