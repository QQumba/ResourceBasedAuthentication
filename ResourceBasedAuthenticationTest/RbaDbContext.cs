using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using ResourceBasedAuthenticationTest.Models;

namespace ResourceBasedAuthenticationTest
{
    public class RbaDbContext : DbContext
    {
        public RbaDbContext(DbContextOptions<RbaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<DepartmentUser> DepartmentUsers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                            e.State is EntityState.Added or EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = (BaseEntity) entry.Entity;
                entity.UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RbaDbContext).Assembly);

            modelBuilder
                .HasDbFunction(
                    typeof(RbaDbContextExtensions).GetMethod(nameof(RbaDbContextExtensions.GetDepartmentUsers),
                        new[] {typeof(int)})!)
                .HasName("get_department_users");
        }
    }
}