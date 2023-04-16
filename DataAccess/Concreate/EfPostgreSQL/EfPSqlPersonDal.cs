using DataAccess.Abstract;
using DataAccess.Concrete.EfPostgreSQL;
using Entities.Concreate;

namespace DataAccess.Concreate.EfPostgreSQL
{
    public class EfPSqlPersonDal : EfEntityRepositoryBase<Person, EfPSqlDbContext>, IPersonDal
    {
    }
}
