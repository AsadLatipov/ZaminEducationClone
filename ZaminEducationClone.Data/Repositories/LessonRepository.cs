using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.Repositories
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(ZaminEducationContext dbcontext) : base(dbcontext)
        {
        }
    }
}
