using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models.Fee;

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
            var appDbContext = _context.SessionFee.Include(s => s.Session).Include(s => s.Standard);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/SessionWiseStandardFee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionFeeMaster = await _context.SessionFee
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (sessionFeeMaster == null)
            {
                return NotFound();
            }

            return View(sessionFeeMaster);
        }

        // GET: Admin/SessionWiseStandardFee/Create
        public IActionResult Create()
        {
            ViewData["SessionId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId");
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId");
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
            ViewData["SessionId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", sessionFeeMaster.SessionId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", sessionFeeMaster.StandardId);
            return View(sessionFeeMaster);
        }

        // GET: Admin/SessionWiseStandardFee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionFeeMaster = await _context.SessionFee.FindAsync(id);
            if (sessionFeeMaster == null)
            {
                return NotFound();
            }
            ViewData["SessionId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", sessionFeeMaster.SessionId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", sessionFeeMaster.StandardId);
            return View(sessionFeeMaster);
        }

        // POST: Admin/SessionWiseStandardFee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,SessionFeeMaster sessionFeeMaster)
        {
            if (id != sessionFeeMaster.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionFeeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionFeeMasterExists(sessionFeeMaster.UniqueId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", sessionFeeMaster.SessionId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", sessionFeeMaster.StandardId);
            return View(sessionFeeMaster);
        }

        // GET: Admin/SessionWiseStandardFee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionFeeMaster = await _context.SessionFee
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (sessionFeeMaster == null)
            {
                return NotFound();
            }

            return View(sessionFeeMaster);
        }

        // POST: Admin/SessionWiseStandardFee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessionFeeMaster = await _context.SessionFee.FindAsync(id);
            if (sessionFeeMaster != null)
            {
                _context.SessionFee.Remove(sessionFeeMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionFeeMasterExists(int id)
        {
            return _context.SessionFee.Any(e => e.UniqueId == id);
        }
    }
}
