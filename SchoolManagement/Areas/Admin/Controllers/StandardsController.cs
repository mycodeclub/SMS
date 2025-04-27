using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
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
            var standards = await _standardService.GetStandardBySession(0);
            return View(standards);
        }

        // GET: Staff/Standards/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var standard = await _standardService.GetStandards(id);
            return View(standard.FirstOrDefault());
        }

        // GET: Staff/Standards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Standards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Standard standard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standard);
        }
         
        // GET: Staff/Standards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        // POST: Staff/Standards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standard = await _context.Standards.FindAsync(id);
            if (standard != null)
            {
                _context.Standards.Remove(standard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandardExists(int id)
        {
            return _context.Standards.Any(e => e.UniqueId == id);
        }
    }
}
