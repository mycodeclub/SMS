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
    public class StandardFeesController : Controller
    {
        private readonly AppDbContext _context;

        public StandardFeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StandardFees
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.StandardFees.Include(s => s.FeeType).Include(s => s.Standard);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/StandardFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardFee = await _context.StandardFees
                .Include(s => s.FeeType)
                .Include(s => s.Standard)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (standardFee == null)
            {
                return NotFound();
            }

            return View(standardFee);
        }

        // GET: Admin/StandardFees/Create
        public IActionResult Create()
        {
            ViewData["FeeTypeId"] = new SelectList(_context.FeeTypes, "FeeTypeId", "FeeTypeId");
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId");
            return View();
        }

        // POST: Admin/StandardFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StandardFee standardFee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standardFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeeTypeId"] = new SelectList(_context.FeeTypes, "FeeTypeId", "FeeTypeId", standardFee.FeeTypeId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", standardFee.StandardId);
            return View(standardFee);
        }

        // GET: Admin/StandardFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardFee = await _context.StandardFees.FindAsync(id);
            if (standardFee == null)
            {
                return NotFound();
            }
            ViewData["FeeTypeId"] = new SelectList(_context.FeeTypes, "FeeTypeId", "FeeTypeId", standardFee.FeeTypeId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", standardFee.StandardId);
            return View(standardFee);
        }

        // POST: Admin/StandardFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StandardFee standardFee)
        {
            if (id != standardFee.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standardFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandardFeeExists(standardFee.UniqueId))
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
            ViewData["FeeTypeId"] = new SelectList(_context.FeeTypes, "FeeTypeId", "FeeTypeId", standardFee.FeeTypeId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", standardFee.StandardId);
            return View(standardFee);
        }

        // GET: Admin/StandardFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardFee = await _context.StandardFees
                .Include(s => s.FeeType)
                .Include(s => s.Standard)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (standardFee == null)
            {
                return NotFound();
            }

            return View(standardFee);
        }

        // POST: Admin/StandardFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standardFee = await _context.StandardFees.FindAsync(id);
            if (standardFee != null)
            {
                _context.StandardFees.Remove(standardFee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandardFeeExists(int id)
        {
            return _context.StandardFees.Any(e => e.UniqueId == id);
        }
    }
}
