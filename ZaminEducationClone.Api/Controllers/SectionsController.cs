using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.SectionDto;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class sectionsController : ControllerBase
    {
        private readonly ISectionService sectionService;
        public sectionsController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

       

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Section>>> CreateAsync(SectionCreateDto sectionDto)
        {
            var result = await sectionService.CreateAsync(sectionDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<Section>>> UpdateASync(SectionUpdateDto section)
        {
            var result = await sectionService.UpdateAsync(section);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{section-id}")]
        public async Task<ActionResult<BaseResponse<Section>>> GetAsync([FromRoute(Name = "section-id")] Guid id)
        {
            var result = await sectionService.GetAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{section-id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync([FromRoute(Name = "section-id")] Guid id)
        {
            var result = await sectionService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Section>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await sectionService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
