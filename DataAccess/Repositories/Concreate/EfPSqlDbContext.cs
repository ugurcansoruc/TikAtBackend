using Entities.Concreate.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concreate
{
    public class EfPSqlDbContext : IdentityDbContext<User, Role, string>
    {
        public EfPSqlDbContext(DbContextOptions<EfPSqlDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            //modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<User> Users { get; set; }
    }
}
