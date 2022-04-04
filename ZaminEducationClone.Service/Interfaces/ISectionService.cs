using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaminEducationClone.Domain.Commons;
using ZaminEducationClone.Domain.Configurations;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Service.DTOs.SectionDto;

namespace ZaminEducationClone.Service.Interfaces
{
    public interface ISectionService
    {
        Task<BaseResponse<Section>> CreateAsync(SectionCreateDto sectionDto);
        Task<BaseResponse<Section>> UpdateAsync(SectionUpdateDto sectionDto);
        Task<BaseResponse<Section>> GetAsync(Expression<Func<Section, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Section, bool>> expression);
        Task<BaseResponse<IEnumerable<Section>>> GetAllAsync(PaginationParams @params, Expression<Func<Section, bool>> expression = null);
        
    }
}