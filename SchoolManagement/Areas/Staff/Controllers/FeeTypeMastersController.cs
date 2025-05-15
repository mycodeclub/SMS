using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models.Fee;

namespace SchoolManagement.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class FeeTypeMastersController : Controller
    {
        private readonly AppDbContext _context;

        public FeeTypeMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Staff/FeeTypeMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeeTypeMaster.ToListAsync());
        }

        // GET: Staff/FeeTypeMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeTypeMaster = await _context.FeeTypeMaster
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (feeTypeMaster == null)
            {
                return NotFound();
            }

            return View(feeTypeMaster);
        }

        // GET: Staff/FeeTypeMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/FeeTypeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionFeeMaster feeTypeMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feeTypeMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feeTypeMaster);
        }

        // GET: Staff/FeeTypeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeTypeMaster = await _context.FeeTypeMaster.FindAsync(id);
            if (feeTypeMaster == null)
            {
                return NotFound();
            }
            return View(feeTypeMaster);
        }

        // POST: Staff/FeeTypeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,FeeType,Description")] SessionFeeMaster feeTypeMaster)
        {
            if (id != feeTypeMaster.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeTypeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeTypeMasterExists(feeTypeMaster.UniqueId))
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
            return View(feeTypeMaster);
        }

        // GET: Staff/FeeTypeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeTypeMaster = await _context.FeeTypeMaster
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (feeTypeMaster == null)
            {
                return NotFound();
            }

            return View(feeTypeMaster);
        }

        // POST: Staff/FeeTypeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeTypeMaster = await _context.FeeTypeMaster.FindAsync(id);
            if (feeTypeMaster != null)
            {
                _context.FeeTypeMaster.Remove(feeTypeMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeTypeMasterExists(int id)
        {
            return _context.FeeTypeMaster.Any(e => e.UniqueId == id);
        }
    }
}
