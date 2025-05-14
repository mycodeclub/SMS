using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models.Fee;
using SchoolManagement.Models.User;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionWiseStandardFeeController : Controller
    {
        private readonly AppDbContext _context;

        public SessionWiseStandardFeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SessionWiseStandardFee
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SesionFeeMaster.Include(s => s.Session).Include(s => s.Standard);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/SessionWiseStandardFee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionFeeMaster = await _context.SesionFeeMaster
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (sessionFeeMaster == null)
            {
                return NotFound();
            }

            return View(sessionFeeMaster);
        }
        [HttpGet]
        // GET: Admin/SessionWiseStandardFee/Create
        public  async Task<IActionResult> Create()
        {
           
            ViewData["SessionId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName");
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionFeeMaster sessionFeeMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionFeeMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName", sessionFeeMaster.SessionId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", sessionFeeMaster.StandardId);
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fee = await _context.SessionFee.FindAsync(id);
            if (fee == null) return NotFound();

            ViewBag.SessionList = _context.SessionYears
                .Select(s => new SelectListItem { Value = s.UniqueId.ToString(), Text = s.SessionName })
                .ToList();

            ViewBag.StandardList = _context.Standards
                .Select(s => new SelectListItem { Value = s.UniqueId.ToString(), Text = s.StandardName })
                .ToList();

            return View(fee);
        }

        // POST: SessionFeeMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SessionFeeMaster sessionFeeMaster)
        {
            if (id != sessionFeeMaster.UniqueId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionFeeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.SessionFee.Any(e => e.UniqueId == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SessionList = _context.SessionYears
                .Select(s => new SelectListItem { Value = s.UniqueId.ToString(), Text = s.SessionName })
                .ToList();


            ViewBag.StandardList = _context.Standards
                .Select(s => new SelectListItem { Value = s.UniqueId.ToString(), Text = s.StandardName })
                .ToList();

            return View(sessionFeeMaster);
        }

        // GET: Admin/SessionWiseStandardFee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var fee = await _context.SessionFee
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .FirstOrDefaultAsync(m => m.UniqueId == id);

            if (fee == null) return NotFound();

            return View(fee);
        }

        // POST: SessionFeeMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fee = await _context.SessionFee.FindAsync(id);
            _context.SessionFee.Remove(fee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionFeeMasterExists(int id)
        {
            return _context.SessionFee.Any(e => e.UniqueId == id);
        }
    }
}
