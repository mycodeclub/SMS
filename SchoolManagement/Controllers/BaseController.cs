using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Services;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{

    public class BaseController(ISessionYearService sessionYearService) : Controller
    {
        private readonly ISessionYearService _sessionYearService = sessionYearService;

        public async Task<string> GetActiveSession()
        {
            var sessionYear = await _sessionYearService.GetActiveSessionYear();
            return "Session - " + sessionYear.SessionName;
        }
    }
}
