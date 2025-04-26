
using SchoolManagement.Models;
using SchoolManagement.Models.User;
using SchoolManagement.ProcModels;

namespace SchoolManagement.Services
{
    public interface IStandardService
    {
        /// <summary>
        /// Get all standards for given session year, pass 0 if needed current session year _ Standards...
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        Task<List<Standard>> GetStandardBySession(int uniqueId);
        Task<Standard> GetStandardById(int standardId, bool includeStudents = false);
        Task<List<SessionDetailsDto>> GetStandards(int standardId = 0);
    }
}
