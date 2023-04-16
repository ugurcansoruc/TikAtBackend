using DataAccess.Concreate.EfPostgreSQL.Mapping;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfPostgreSQL
{
    public class EfPSqlDbContext : DbContext
    {
        public EfPSqlDbContext(DbContextOptions<EfPSqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new PersonMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Persons { get; set; }
    }
}
