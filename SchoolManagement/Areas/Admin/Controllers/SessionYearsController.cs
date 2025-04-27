
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionYearsController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly ISessionYearService _sessionService;
        private readonly IStandardService _standardService;

        public SessionYearsController(AppDbContext context, ISessionYearService service, IStandardService standardService) : base(service)
        {
            _context = context;
            _sessionService = service;
            _standardService = standardService;
        }

        // GET: Staff/SessionYears
        public async Task<IActionResult> Index(int id)
        {
            if (id > 0)
            {
                await _sessionService.SetSelectedSessionById(id);
                SetSelectedSessionTempData();
            }

            var sessionYearsTask = _sessionService.GetAllSessionYears();
            var activeSessionTask = GetActiveSession();
            await Task.WhenAll(sessionYearsTask, activeSessionTask);
            ViewBag.ActiveSession = activeSessionTask.Result;
            return View(sessionYearsTask.Result);
        }


        // GET: Staff/SessionYears/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var sessionYear = await _sessionService.GetSessionYearById(id);
            ViewBag.Standards = await _standardService.GetStandards(id, 0);   // getting all standers
            return View(sessionYear);
        }

        // GET: Staff/SessionYears/Create
        public async Task<IActionResult> Create(int id)
        {
            var session = await _context.SessionYears.FindAsync(id);
            if (session != null)
                return View(session);

            var lastSession = await _context.SessionYears.OrderByDescending(s => s.EndDate).FirstOrDefaultAsync();
            session = lastSession == null
                ? new SessionYear
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    IsAcitve = true
                }
                : new SessionYear
                {
                    SessionName = $"Session {DateTime.Now.Year}",
                    StartDate = lastSession.StartDate.AddYears(1),
                    EndDate = lastSession.EndDate.AddYears(1),
                    IsAcitve = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
            return View(session);
        }

        // POST: Staff/SessionYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionYear sessionYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sessionYear);
        }

        // GET: Staff/SessionYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionYear = await _context.SessionYears.FindAsync(id);
            if (sessionYear == null)
            {
                return NotFound();
            }
            return View(sessionYear);
        }



        // GET: Staff/SessionYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionYear = await _context.SessionYears
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (sessionYear == null)
            {
                return NotFound();
            }

            return View(sessionYear);
        }

        // POST: Staff/SessionYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessionYear = await _context.SessionYears.FindAsync(id);
            if (sessionYear != null)
            {
                _context.SessionYears.Remove(sessionYear);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionYearExists(int id)
        {
            return _context.SessionYears.Any(e => e.UniqueId == id);
        }
    }
}
