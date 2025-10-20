using IpsAusentismos.Data;
using IpsAusentismos.Services;
using Microsoft.EntityFrameworkCore;

namespace IpsAusentismos.Infrastructure
{
    public static class ServiceLocator
    {
        private static IDbContextFactory<AppDbContext> _factory = null!;
        public static IDbContextFactory<AppDbContext> DbFactory => _factory;

        public static PasswordService Passwords { get; } = new();
        public static UserService UserService { get; private set; } = null!;
        public static EventService EventService { get; private set; } = null!;
        public static VacationService VacationService { get; private set; } = null!;

        static ServiceLocator()
        {
            var opts = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(Configuration.ConnectionString)
                .Options;

            _factory = new SimpleFactory(opts);

            UserService     = new UserService(_factory, Passwords);
            EventService    = new EventService(_factory);
            VacationService = new VacationService(_factory);

            _ = UserService.SeedAdminAsync();
        }
    }

    // Simple factory compatible con todas las versiones de EF Core
    public class SimpleFactory : IDbContextFactory<AppDbContext>
    {
        private readonly DbContextOptions<AppDbContext> _opts;
        public SimpleFactory(DbContextOptions<AppDbContext> opts) => _opts = opts;
        public AppDbContext CreateDbContext() => new AppDbContext(_opts);
    }
}
