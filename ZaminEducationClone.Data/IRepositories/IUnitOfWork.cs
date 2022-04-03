using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ILessonRepository LessonRepository { get; }
        ISectionRepository SectionRepository { get; }
        ICourseRepository CourseRepository { get; }
        ITopicRepository TopicRepository { get; }
        Task SaveChangesAsync();
    }
}
