using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}