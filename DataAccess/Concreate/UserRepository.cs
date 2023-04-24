using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concreate
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
