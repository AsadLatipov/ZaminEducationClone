using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            UserRepository = new UserRepository(context);
            LessonRepository = new LessonRepository(context);
            CourseRepository = new CourseRepository(context);
            SectionRepository = new SectionRepository(context);
            TopicRepository = new TopicRepository(context);
        }
        public IUserRepository UserRepository { get; private set; }

        public ILessonRepository LessonRepository { get; private set; }

        public ISectionRepository SectionRepository { get; private set; }

        public ICourseRepository CourseRepository { get; private set; }

        public ITopicRepository TopicRepository { get; private set; }

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
