using System.Reflection;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RbaDbContext).Assembly);
        }
    }
}