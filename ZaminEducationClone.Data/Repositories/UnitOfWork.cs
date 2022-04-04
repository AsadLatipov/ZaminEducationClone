using System;
using System.Threading.Tasks;
using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;

namespace ZaminEducationClone.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZaminEducationContext context;
        public UnitOfWork(ZaminEducationContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            Lessons = new LessonRepository(context);
            Courses = new CourseRepository(context);
            Sections = new SectionRepository(context);
            Topics = new TopicRepository(context);
        }
        public IUserRepository Users { get; private set; }

        public ILessonRepository Lessons { get; private set; }

        public ISectionRepository Sections { get; private set; }

        public ICourseRepository Courses { get; private set; }

        public ITopicRepository Topics { get; private set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
