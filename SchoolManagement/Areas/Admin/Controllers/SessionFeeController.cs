using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionFeeController : BaseController
    {
        private readonly AppDbContext _context;

        public SessionFeeController(AppDbContext context, ISessionYearService sessionYearService) : base(sessionYearService)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var session = await _context.SessionYears.ToListAsync();

            ViewBag.ActiveSession = await GetActiveSession();

            return View();
        }

        public IActionResult SessionFee()
        {
            return View();
        }
    }
}
