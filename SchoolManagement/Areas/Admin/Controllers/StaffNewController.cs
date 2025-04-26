using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.User;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class StaffNewController : BaseController
    {
        private readonly AppDbContext _context;

        public StaffNewController(AppDbContext context, ISessionYearService sessionYearService) : base(sessionYearService)
        {
            _context = context;
        }

        // GET: Admin/StaffNew
        public async Task<IActionResult> Index()
        {
            var stafflist = await _context.StaffNewModels.Include(s => s.SessionYear).ToListAsync();
            ViewBag.ActiveSession = await GetActiveSession();
            return View(stafflist);
        }

        // GET: Admin/StaffNew/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNewModel = await _context.StaffNewModels
                .Include(s => s.SessionYear)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNewModel == null)
            {
                return NotFound();
            }

            return View(staffNewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var staffNewModel = await _context.StaffNewModels.FirstOrDefaultAsync();

            return View(staffNewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffNewModel staffNewModel)
        {
            if (ModelState.IsValid)
            {
                if (staffNewModel == null)
                    staffNewModel = new StaffNewModel
                    {
                        SessionYearId = 1,
                        DOB = DateTime.Now.AddYears(-2)
                    };
                _context.Add(staffNewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", staffNewModel.SessionYearId);
            return View(staffNewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNewModel = await _context.StaffNewModels.FindAsync(id);
            if (staffNewModel == null)
            {
                return NotFound();
            }
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", staffNewModel.SessionYearId);
            return View(staffNewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StaffNewModel staffNewModel)
        {
            if (id != staffNewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffNewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffNewModelExists(staffNewModel.Id))
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
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", staffNewModel.SessionYearId);
            return View(staffNewModel);
        }

        // GET: Admin/StaffNew/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNewModel = await _context.StaffNewModels
                .Include(s => s.SessionYear)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNewModel == null)
            {
                return NotFound();
            }

            return View(staffNewModel);
        }

        // POST: Admin/StaffNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffNewModel = await _context.StaffNewModels.FindAsync(id);
            if (staffNewModel != null)
            {
                _context.StaffNewModels.Remove(staffNewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffNewModelExists(int id)
        {
            return _context.StaffNewModels.Any(e => e.Id == id);
        }
    }
}
