using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.CourseDto;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Api.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class coursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        public coursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<Course>>> CreateAsync([FromForm]CourseCreateDto sectionDto)
        {
            var result = await courseService.CreateAsync(sectionDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<Course>>> UpdateASync(CourseUpdateDto section)
        {
            var result = await courseService.UpdateAsync(section);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{course-id}")]
        public async Task<ActionResult<BaseResponse<Course>>> GetAsync([FromRoute(Name = "course-id")] Guid id)
        {
            var result = await courseService.GetAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{course-id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync([FromRoute(Name = "course-id")] Guid id)
        {
            var result = await courseService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Course>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await courseService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
