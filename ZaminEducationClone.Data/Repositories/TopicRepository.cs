using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ZaminEducationContext context) : base(context)
        {
        }
    }
}
