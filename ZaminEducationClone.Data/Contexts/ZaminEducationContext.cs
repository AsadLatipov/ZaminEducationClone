using Microsoft.EntityFrameworkCore;
using ZaminEducationClone.Domain.Entities.Courses;
using ZaminEducationClone.Domain.Entities.Users;

namespace ZaminEducationClone.Data.Contexts
{
    public class ZaminEducationContext : DbContext
    {
        public ZaminEducationContext(DbContextOptions<ZaminEducationContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
