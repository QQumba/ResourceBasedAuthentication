using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest.Configurations
{
    public class DepartmentUserConfiguration : IEntityTypeConfiguration<DepartmentUser>
    {
        public void Configure(EntityTypeBuilder<DepartmentUser> builder)
        {
            builder.ToTable("department_user");
            builder.ConfigureBaseEntity();

            builder.Property(du => du.DepartmentId).HasColumnName("department_id");
            builder.Property(du => du.UserId).HasColumnName("user_id");
            
            builder.HasIndex(du => new { du.DepartmentId, du.UserId }).IsUnique();
        }
    }
}