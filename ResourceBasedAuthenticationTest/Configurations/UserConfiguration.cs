﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.ConfigureBaseEntity();

            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.Login).HasColumnName("login");
            
            builder
                .HasMany<DepartmentUser>()
                .WithOne(du => du.User)
                .HasForeignKey(du => du.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}