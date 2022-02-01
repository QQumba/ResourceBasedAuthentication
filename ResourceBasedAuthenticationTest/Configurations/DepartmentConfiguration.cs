using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("department");
            builder.ConfigureBaseEntity();
            
            builder.Property(d => d.Name).HasColumnName("name").IsRequired();

            builder
                .HasMany<DepartmentUser>()
                .WithOne(du => du.Department)
                .HasForeignKey(du => du.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}