using ZaminEducationClone.Data.Contexts;
using ZaminEducationClone.Data.IRepositories;
using ZaminEducationClone.Domain.Entities.Users;

namespace ZaminEducationClone.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ZaminEducationContext dbcontext) : base(dbcontext)
        {
        }
    }
}
