using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SchoolManagement.Data;
using SchoolManagement.Models;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class SessionYearService : ISessionYearService
    {
        private AppDbContext _context;
        private readonly IMemoryCache _cache;
        public SessionYearService(AppDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<SessionYear>> GetAllSessionYears()
        {
            if (!_cache.TryGetValue("GetAllSessionYears", out List<SessionYear> sessions))
            {
                sessions = await _context.SessionYears.ToListAsync();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(24));
                _cache.Set("GetAllSessionYears", sessions, cacheOptions);
            }
            return sessions;
        }
        public async Task<SessionYear> GetSessionYearById(int sessionYearId)
        {
            var sessions = await GetAllSessionYears();
            return sessions.Where(s => s.UniqueId == sessionYearId).FirstOrDefault();
        }
        public async Task<SessionYear> AddSessionYear(SessionYear sy)
        {
            _context.SessionYears.Add(sy);
            await _context.SaveChangesAsync();
            return sy;
        }
        public async Task<SessionYear> UpdateSessionYear(SessionYear sy)
        {
            var dbSession = await _context.SessionYears.FindAsync(sy.UniqueId);
            if (dbSession != null)
            {
                dbSession.SessionName = sy.SessionName;
                dbSession.StartDate = sy.StartDate;
                dbSession.EndDate = sy.EndDate;
                dbSession.IsAcitve = sy.IsAcitve;
                dbSession.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return dbSession;
        }
        public Task<bool> DeleteSessionYear(int sessionYearId)
        {
            _context.SessionYears.Remove(_context.SessionYears.Find(sessionYearId));
            return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
        public async Task<SessionYear> GetActiveSessionYear()
        {
            if (!_cache.TryGetValue("GetAllSessionYears", out List<SessionYear> sessions))
                sessions = await GetAllSessionYears();
            return sessions.FirstOrDefault(s => s.IsAcitve);
        }
        public SessionYear GetSelectedSession()
        {
            if (!_cache.TryGetValue("SelectedSessionYears", out SessionYear session))
            {
                session = GetActiveSessionYear().GetAwaiter().GetResult();
                SetSelectedSession(session);
            }
            return session ?? throw new InvalidOperationException("No selected session found."); // Handle null case explicitly
        }

        public void SetSelectedSession(SessionYear session)
        {
            _cache.Set("SelectedSessionYears", session, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(24)));
        }

        public async Task SetSelectedSessionById(int id)
        {
            SetSelectedSession(await GetSessionYearById(id));
        }
    }
}
