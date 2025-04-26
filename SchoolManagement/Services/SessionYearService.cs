using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Services
{
    public class SessionYearService : ISessionYearService
    {
        public AppDbContext _context;
        public SessionYearService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SessionYear> AddSessionYear(SessionYear sy)
        {
            _context.SessionYears.Add(sy);
            await _context.SaveChangesAsync();
            return sy;
        }

        public Task<bool> DeleteSessionYear(int sessionYearId)
        {
            _context.SessionYears.Remove(_context.SessionYears.Find(sessionYearId));
            return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public async Task<SessionYear> GetActiveSessionYear()
        {
            return await _context.SessionYears.FirstOrDefaultAsync(s => s.IsAcitve);
        }

        public async Task<List<SessionYear>> GetAllSessionYears()
        {
            return await _context.SessionYears.ToListAsync();
        }

        public Task<bool> IsSessionYearActive(int sessionYearId)
        {
            throw new NotImplementedException();
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
         
    }
}
