using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concreate
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
