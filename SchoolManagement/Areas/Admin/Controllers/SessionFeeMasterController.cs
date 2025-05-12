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
    public class SessionFeeMasterController : Controller
    {
        private readonly AppDbContext _context;

        public SessionFeeMasterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SesionFeeMaster
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _context.SessionFee.Include(s => s.Standard).Include(s => s.StudentFee).ToListAsync();
            return View(appDbContext);
        }

        // GET: Admin/SesionFeeMaster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionFeeMaster = await _context.SessionFee
                .Include(s => s.Standard)
                .Include(s => s.StudentFee)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (sesionFeeMaster == null)
            {
                return NotFound();
            }

            return View(sesionFeeMaster);
        }

        // GET: Admin/SesionFeeMaster/Create
        public IActionResult Create()
        {
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId");
            ViewData["StudentFeeId"] = new SelectList(_context.StudentFees, "UniqueId", "UniqueId");
            return View();
        }

        // POST: Admin/SesionFeeMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionFeeMaster sesionFeeMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesionFeeMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", sesionFeeMaster.StandardId);
            ViewData["StudentFeeId"] = new SelectList(_context.StudentFees, "UniqueId", "UniqueId", sesionFeeMaster.StudentFeeId);
            return View(sesionFeeMaster);
        }

        // GET: Admin/SesionFeeMaster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionFeeMaster = await _context.SessionFee.FindAsync(id);
            if (sesionFeeMaster == null)
            {
                return NotFound();
            }
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", sesionFeeMaster.StandardId);
            ViewData["StudentFeeId"] = new SelectList(_context.StudentFees, "UniqueId", "UniqueId", sesionFeeMaster.StudentFeeId);
            return View(sesionFeeMaster);
        }

        // POST: Admin/SesionFeeMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SessionFeeMaster sesionFeeMaster)
        {
            if (id != sesionFeeMaster.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesionFeeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesionFeeMasterExists(sesionFeeMaster.UniqueId))
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
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", sesionFeeMaster.StandardId);
            ViewData["StudentFeeId"] = new SelectList(_context.StudentFees, "UniqueId", "UniqueId", sesionFeeMaster.StudentFeeId);
            return View(sesionFeeMaster);
        }

        // GET: Admin/SesionFeeMaster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionFeeMaster = await _context.SessionFee
                .Include(s => s.Standard)
                .Include(s => s.StudentFee)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (sesionFeeMaster == null)
            {
                return NotFound();
            }

            return View(sesionFeeMaster);
        }

        // POST: Admin/SesionFeeMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesionFeeMaster = await _context.SessionFee.FindAsync(id);
            if (sesionFeeMaster != null)
            {
                _context.SesionFeeMaster.Remove(sesionFeeMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesionFeeMasterExists(int id)
        {
            return _context.SesionFeeMaster.Any(e => e.UniqueId == id);
        }
    }
}
