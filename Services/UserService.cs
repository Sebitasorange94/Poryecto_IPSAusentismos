using IpsAusentismos.Data;
using IpsAusentismos.Models;
using Microsoft.EntityFrameworkCore;

namespace IpsAusentismos.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        private readonly PasswordService _pwd;
        public UserService(IDbContextFactory<AppDbContext> factory, PasswordService pwd)
        { _factory = factory; _pwd = pwd; }

        public async Task<User?> LoginAsync(string username, string password)
        {
            using var db = await _factory.CreateDbContextAsync();
            var u = await db.Users.Include(x => x.Role)
                                  .FirstOrDefaultAsync(x => x.Username == username && x.IsActive);
            if (u == null) return null;
            return _pwd.Verify(u, password) ? u : null;
        }

        public async Task SeedAdminAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            if (!await db.Users.AnyAsync())
            {
                var admin = new User { Username = "admin", FirstName = "Admin", LastName = "Sistema", RoleId = 1, IsActive = true };
                admin.PasswordHash = _pwd.Hash(admin, "Admin123!");
                db.Users.Add(admin);
                await db.SaveChangesAsync();
            }
        }
    }
}
