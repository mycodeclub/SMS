

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using SchoolManagement.Controllers;

using SchoolManagement.Data;

using SchoolManagement.Models;

using SchoolManagement.Services;
using System.Net.NetworkInformation;

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

        [HttpPost]

        public async Task<IActionResult> SetActiveSession(int id)

        {

            var isUpdated = false;

            try

            {

                var session = await _context.SessionYears.ToListAsync();

                session.ForEach(s =>

                {

                    s.IsAcitve = s.UniqueId == id;

                    if (s.IsAcitve) s.UpdatedDate = DateTime.UtcNow;

                });

                await _context.SaveChangesAsync();

                isUpdated = true;

            }

            catch { }

            return Ok(isUpdated);

        }

        // GET: Staff/SessionYears

        public async Task<IActionResult> Index(int id)
        {
            if (id > 0)
            {
                await _sessionService.SetSelectedSessionById(id);

               SetSelectedSessionTempData();
            }

            var sessionYearsTask = _sessionService.GetAllSessionsFromDb();

            var activeSessionTask = GetActiveSession();

            await Task.WhenAll(sessionYearsTask, activeSessionTask);

            ViewBag.ActiveSession = activeSessionTask.Result;

            return View(sessionYearsTask.Result);
        }


        // GET: Staff/SessionYears/Details/5

        public async Task<IActionResult> Details(int id)

        {

            var sessionYear = await _sessionService.GetSessionYearById(id);

            // ViewBag.Standards = await _standardService.GetStandardsByProc(id);   // getting all standers

            ViewBag.Standards = await _standardService.GetStandardsBySession(id);   // getting all standers

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

                if (sessionYear.UniqueId == 0)

                {

                    sessionYear.CreatedDate = DateTime.Now;

                    _context.SessionYears.Add(sessionYear);

                }

                else _context.SessionYears.Update(sessionYear);

                sessionYear.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(sessionYear);

        }

        [HttpPost]

        public JsonResult DeleteConfirmed(int id)

        {

            try

            {

                var session = _context.SessionYears.Find(id);

                if (session == null)

                    return Json(new { success = false, error = "Session not found." });

                _context.SessionYears.Remove(session);

                _context.SaveChanges();

                return Json(new { success = true });

            }

            catch (Exception ex)

            {

                return Json(new { success = false, error = ex.Message });

            }

        }


        private bool SessionYearExists(int id)

        {

            return _context.SessionYears.Any(e => e.UniqueId == id);
        }

    }

}

