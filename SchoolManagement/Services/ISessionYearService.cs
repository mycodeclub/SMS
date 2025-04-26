using SchoolManagement.Models;

namespace SchoolManagement.Services
{
    public interface ISessionYearService
    {
        public Task<bool> IsSessionYearActive(int sessionYearId);

        public Task<SessionYear> GetActiveSessionYear();
        public Task<List<SessionYear>> GetAllSessionYears();
        public Task<SessionYear> AddSessionYear(SessionYear sy);
        public Task<bool> DeleteSessionYear(int sessionYearId);
        public Task<SessionYear> UpdateSessionYear(SessionYear sy);
    }
}
