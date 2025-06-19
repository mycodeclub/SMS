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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var appDbContext = await _context.StandardFees
                .Include(s => s.FeeType)
                .Include(s => s.Standard)
                .ToListAsync();

            foreach (var item in appDbContext)
            {
                if (item.FeeType != null)
                {
                    Console.WriteLine(item.FeeType.Name);
                }
                else
                {
                    Console.WriteLine("FeeType is null for StandardFee ID: " + item.UniqueId);
                }
            }


            return View(appDbContext);
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

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            StandardFee model = new StandardFee();

            if (id.HasValue && id.Value > 0)
            {
                model = await _context.StandardFees.FindAsync(id.Value);
                if (model == null)
                {
                    return NotFound();
                }
            }

            ViewData["FeeTypeId"] = new SelectList(_context.FeeTypes, "FeeTypeId", "Name", model?.FeeTypeId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", model?.StandardId);

            return View(model);
        }

        // POST: StandardFees/Create or Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StandardFee model)
        {
            ModelState.Remove("Standard");
            ModelState.Remove("FeeType");
            if (ModelState.IsValid)
            {
                if (model.UniqueId == 0)
                {
                    // Create
                    _context.StandardFees.Add(model);
                }
                else
                {
                    // Update
                    try
                    {
                        _context.StandardFees.Update(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StandardFeeExists(model.UniqueId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FeeTypeId"] = new SelectList(_context.FeeTypes, "FeeTypeId", "Name", model.FeeTypeId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", model.StandardId);

            return View(model);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var standardFee = _context.StandardFees.Find(id);
            if (standardFee == null)
            {
                return Json(new { success = false, error = "Standard Fee not found." });
            }

            try
            {
                _context.StandardFees.Remove(standardFee);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }


        private bool StandardFeeExists(int id)
        {
            return _context.StandardFees.Any(e => e.UniqueId == id);
        }
    }
}
