﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaminEducationClone.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ILessonRepository Lessons { get; }
        ISectionRepository Sections { get; }
        ICourseRepository Courses { get; }
        ITopicRepository Topics { get; }
        Task SaveChangesAsync();
    }
}
