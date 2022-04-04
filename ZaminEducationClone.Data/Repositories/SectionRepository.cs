using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.Repositories
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(ZaminEducationContext context) : base(context)
        {
        }
    }

}
