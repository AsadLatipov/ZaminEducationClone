using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Entities.Courses;

namespace ZaminEducationClone.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ZaminEducationContext dbcontext) : base(dbcontext)
        {
        }
    }
}
