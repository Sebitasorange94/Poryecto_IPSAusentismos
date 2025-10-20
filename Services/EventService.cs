using IpsAusentismos.Data;
using IpsAusentismos.Models;
using Microsoft.EntityFrameworkCore;

namespace IpsAusentismos.Services
{
    public class EventService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public EventService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

        public async Task<List<Event>> GetAsync(DateTime? from=null, DateTime? to=null, EventType? type=null)
        {
            using var db = await _factory.CreateDbContextAsync();
            var q = db.Events.AsNoTracking()
                             .Include(e => e.Employee).ThenInclude(emp => emp.User)
                             .AsQueryable();
            if (from.HasValue) q = q.Where(x => x.Date >= from);
            if (to.HasValue)   q = q.Where(x => x.Date <= to);
            if (type.HasValue) q = q.Where(x => x.Type == type);
            return await q.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<Event> CreateAsync(Event ev)
        {
            using var db = await _factory.CreateDbContextAsync();
            db.Events.Add(ev);
            await db.SaveChangesAsync();
            return ev;
        }
    }
}
