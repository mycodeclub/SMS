using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.User;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StandardsController : Controller
    {
        [Obsolete]
        private readonly AppDbContext _context;
        private readonly ISessionYearService _sessionService;
        private readonly IStandardService _standardService;

        public StandardsController(IStudentService studentService, AppDbContext context, ISessionYearService sessionService, IStandardService standardService)
        {
            _sessionService = sessionService;
            _standardService = standardService;
        }

        // GET: Staff/Standards
        public async Task<IActionResult> Index()
        {

            var standards = await _standardService.GetStandardsByProc(_sessionService.GetSelectedSession().UniqueId);
            return View(standards);
        }

        // GET: Staff/Standards/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var standard = await _standardService.GetStandardsByProc(id);
            return View(standard.FirstOrDefault());
        }

        // GET: Staff/Standards/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Standard standard)
        {
            if (ModelState.IsValid)
            {
                await _standardService.GetStandardsByProc(standard.UniqueId);

                return RedirectToAction(nameof(Index));
            }
            return View(standard);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var standard = await _standardService.GetStandardById(id.Value);
            if (standard == null)
                return NotFound();

            return View(standard);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _standardService.GetStandardById(id);
            return RedirectToAction(nameof(Index));
        }
        private bool StandardExists(int id)
        {
            return _context.Standards.Any(e => e.UniqueId == id);
        }
    }
}
