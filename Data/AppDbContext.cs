using IpsAusentismos.Models;
using Microsoft.EntityFrameworkCore;

namespace IpsAusentismos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Vacation> Vacations => Set<Vacation>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<User>().HasIndex(x => x.Username).IsUnique();

            b.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "RRHH" },
                new Role { Id = 3, Name = "Empleado" }
            );
        }
    }
}
