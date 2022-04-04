using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.LessonDto;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class lessonsController : ControllerBase
    {
        private readonly ILessonService lessonService;
        public lessonsController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<Lesson>>> CreateAsync([FromForm]LessonCreateDto sectionDto)
        {
            var result = await lessonService.CreateAsync(sectionDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<Lesson>>> UpdateASync(LessonUpdateDto section)
        {
            var result = await lessonService.UpdateAsync(section);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{lesson-id}")]
        public async Task<ActionResult<BaseResponse<Lesson>>> GetAsync([FromRoute(Name = "lesson-id")] Guid id)
        {
            var result = await lessonService.GetAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{lesson-id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync([FromRoute(Name = "lesson-id")] Guid id)
        {
            var result = await lessonService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Lesson>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await lessonService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
