using DataAccess.Abstract;
using DataAccess.Concrete.EfPostgreSQL;
using Entities.Concreate;

namespace DataAccess.Concreate.EfPostgreSQL
{
    public class EfPSqlUserDal : EfEntityRepositoryBase<User, EfPSqlDbContext>, IUserDal
    {
    }
}
