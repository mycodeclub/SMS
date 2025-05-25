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
    public class FeeTypesController : Controller
    {
        private readonly AppDbContext _context;

        public FeeTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FeeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeeTypes.ToListAsync());
        }

        // GET: Admin/FeeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes
                .FirstOrDefaultAsync(m => m.FeeTypeId == id);
            if (feeType == null)
            {
                return NotFound();
            }

            return View(feeType);
        }

        // GET: Admin/FeeTypes/Create
        public async Task<IActionResult> Create(int? id)
        {
            FeeType feeType;

            if (id == null || id == 0)
            {
                feeType = new FeeType();
            }
            else
            {
                feeType = await _context.FeeTypes.FindAsync(id);
                if (feeType == null)
                {
                    return NotFound();
                }
            }

            return View(feeType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeeType feeType)
        {
            if (ModelState.IsValid)
            {
                if (feeType.FeeTypeId == 0)
                {
                    // Create new
                    _context.Add(feeType);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Update existing
                    _context.Update(feeType);
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(feeType);
        }




        // POST: Admin/FeeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      

        // POST: Admin/FeeTypes/Delete/5 (for AJAX)
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var feeType = await _context.FeeTypes.FindAsync(id);
            if (feeType != null)
            {
                _context.FeeTypes.Remove(feeType);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false, error = "Not found" });
        }

        private bool FeeTypeExists(int id)
        {
            return _context.FeeTypes.Any(e => e.FeeTypeId == id);
        }
    }
}
