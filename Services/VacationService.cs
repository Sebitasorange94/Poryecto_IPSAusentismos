using IpsAusentismos.Data;
using IpsAusentismos.Models;
using Microsoft.EntityFrameworkCore;

namespace IpsAusentismos.Services
{
    public class VacationService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public VacationService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

        public async Task<Vacation> CreateAsync(Vacation v)
        {
            using var db = await _factory.CreateDbContextAsync();
            db.Vacations.Add(v);
            await db.SaveChangesAsync();
            return v;
        }
    }
}
