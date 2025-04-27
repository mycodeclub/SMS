using SchoolManagement.Models;

namespace SchoolManagement.Services
{
    public interface ISessionYearService
    {
        public Task<List<SessionYear>> GetAllSessionYears();
        public Task<SessionYear> GetSessionYearById(int sessionYearId);
        public Task<SessionYear> AddSessionYear(SessionYear sy);
        public Task<SessionYear> UpdateSessionYear(SessionYear sy);
        public Task<bool> DeleteSessionYear(int sessionYearId);

        public Task<SessionYear> GetActiveSessionYear();

        public SessionYear GetSelectedSession();
        public void SetSelectedSession(SessionYear session);
    }
}
