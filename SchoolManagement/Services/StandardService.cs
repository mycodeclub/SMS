using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.ProcModels;

namespace SchoolManagement.Services
{
    public class StandardService(AppDbContext context, ISessionYearService sessionService, IStudentService studentService) : IStandardService
    {
        private readonly AppDbContext _context = context;
        private readonly ISessionYearService _sessionService = sessionService;
        private readonly IStudentService _studentService = studentService;

        public async Task<List<Standard>> GetStandardsBySession(int sessionId = 0)
        {
            if (sessionId == 0)
                sessionId = _sessionService.GetSelectedSession().UniqueId; 
            return await _context.Standards.Where(s => s.SessionYearId == sessionId).ToListAsync();
        }

        public async Task<List<SessionDetailsDto>> GetStandardsByProc(int sessionId = 0, int standardId = 0)
        {
            if (sessionId == 0)
            {
                var _selectedSession = _sessionService.GetSelectedSession();
                sessionId = _selectedSession.UniqueId;
            }

            List<SessionDetailsDto> _standerd;
            _standerd = await _context.Database
               .SqlQuery<SessionDetailsDto>($"EXEC GetSessionDetailsByStandard @SessionId = {sessionId}, @StandardId = {standardId}")
               .ToListAsync();
            return _standerd;
        }
        [Obsolete]
        public async Task<List<Standard>> GetStandardBySession(int sessionId)
        {
            if (sessionId == 0)
                sessionId = _sessionService.GetActiveSessionYear().Result.UniqueId;
            var standards = await _context.Standards
                .Where(s => s.UniqueId == sessionId)
                .ToListAsync();
            return standards;
        }

        public Task<Standard> GetStandardById(int standardId, bool includeStudents = false)
        {
            throw new NotImplementedException();
        }
    }
}
