using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.SectionDto;
using ZaminEducationClone.Service.Helpers;
using ZaminEducationClone.Service.Interfaces;

namespace ZaminEducationClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class sectionsController : ControllerBase
    {
        private readonly ISectionService sectionService;
        private readonly IConfiguration con;


        public sectionsController(ISectionService sectionService,
            IConfiguration con)
        {
            this.sectionService = sectionService;
            this.con = con;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Section>>> GetAsync(Guid id)
        {
            var result = await sectionService.GetAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteAsync(Guid id)
        {
            var result = await sectionService.DeleteAsync(obj => obj.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Section>>>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            string user = con.GetSection("Authorization:User").Value;
            string password = con.GetSection("Authorization:Password").Value;

            if (user == AccesToContext.BasicUser && password == AccesToContext.BasicPassword)
            {
                //var result = await sectionService.GetAllAsync(@params);

                var result = new BaseResponse<IEnumerable<Section>>
                {

                    Data = new List<Section>()
                    {
                        new Section()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Ishladi"
                        }
                    },
                    Error = null,
                    Code = 200

                };
                return StatusCode(result.Code ?? result.Error.Code.Value, result);

            }
            return Unauthorized();


        }
    }
}
