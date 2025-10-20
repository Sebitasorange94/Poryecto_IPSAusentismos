using IpsAusentismos.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IpsAusentismos.Data
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            Configuration.Load();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(Configuration.ConnectionString)
                .Options;
            return new AppDbContext(options);
        }
    }
}
