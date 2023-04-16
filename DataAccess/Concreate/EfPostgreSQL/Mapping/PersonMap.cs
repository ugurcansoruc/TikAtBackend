using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Concreate.EfPostgreSQL.Mapping
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public PersonMap() {}
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonID);
            builder.Property(p => p.PersonID).UseIdentityColumn();

            builder.Property(p => p.PersonID).HasColumnName("PersonID");
            builder.Property(p => p.FirstName).HasColumnName("FirstName");
            builder.Property(p => p.LastName).HasColumnName("LastName");
            builder.Property(p => p.Age).HasColumnName("Age");
            builder.ToTable("Persons");
        }
    }
}
