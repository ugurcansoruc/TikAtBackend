﻿using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Concreate.EfPostgreSQL.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public UserMap() {}
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).UseIdentityColumn();

            builder.Property(p => p.ID).HasColumnName("ID");
            builder.Property(p => p.FirstName).HasColumnName("FirstName");
            builder.Property(p => p.LastName).HasColumnName("LastName");
            builder.Property(p => p.Age).HasColumnName("Age");
            builder.ToTable("Users");
        }
    }
}