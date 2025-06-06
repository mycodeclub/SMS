﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.Fee;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StandardsController(AppDbContext context, ISessionYearService sessionYearService) : BaseController(sessionYearService)
    {
        private readonly AppDbContext _context = context;

        // GET: Admin/Standards
        public async Task<IActionResult> Index()
        {
            var _selectedSession = _sessionYearService.GetSelectedSession();
            var appDbContext = _context.Standards.Where(s => s.SessionYearId == _selectedSession.UniqueId);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Standards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards
                .Include(s => s.SessionYear)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        // GET: Admin/Standards/Create
        public IActionResult Create()
        {
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId");
            return View();
        }

        // POST: Admin/Standards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniqueId,StandardName,SessionYearId")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", standard.SessionYearId);
            return View(standard);
        }

        // GET: Admin/Standards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards.FindAsync(id);
            if (standard == null)
            {
                return NotFound();
            }
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", standard.SessionYearId);
            return View(standard);
        }

        // POST: Admin/Standards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,StandardName,SessionYearId")] Standard standard)
        {
            if (id != standard.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandardExists(standard.UniqueId))
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
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", standard.SessionYearId);
            return View(standard);
        }

        // GET: Admin/Standards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards
                .Include(s => s.SessionYear)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        // POST: Admin/Standards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standard = await _context.Standards.FindAsync(id);
            if (standard != null)
            {
                _context.Standards.Remove(standard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Standards/ManageFees/5
        public async Task<IActionResult> ManageFees(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standard = await _context.Standards
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (standard == null)
            {
                return NotFound();
            }

            // Get all fee types
            var feeTypes = await _context.FeeTypes.ToListAsync();
            
            // Get existing standard fees
            var standardFees = await _context.StandardFees
                .Where(sf => sf.StandardId == id)
                .ToListAsync();

            var viewModel = new StandardFeeViewModel
            {
                StandardId = standard.UniqueId,
                StandardName = standard.StandardName,
                FeeTypes = feeTypes.Select(ft => new FeeTypeViewModel
                {
                    FeeTypeId = ft.FeeTypeId,
                    Name = ft.Name,
                    IsRecurring = ft.IsRecurring,
                    Frequency = ft.Frequency,
                  //  DueDate = ft.DueDate,
                    IsOptional = ft.IsOptional,
                    ApplicableFromMonth = ft.ApplicableFromMonth,
                    Amount = standardFees.FirstOrDefault(sf => sf.FeeTypeId == ft.FeeTypeId)?.Amount ?? 0,
                    DueDate = standardFees.FirstOrDefault(sf => sf.FeeTypeId == ft.FeeTypeId)?.DueDate,
                    IsSelected = standardFees.Any(sf => sf.FeeTypeId == ft.FeeTypeId)
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: Admin/Standards/ManageFees/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageFees(int id, StandardFeeViewModel viewModel)
        {
            if (id != viewModel.StandardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Remove existing fees
                    var existingFees = await _context.StandardFees
                        .Where(sf => sf.StandardId == id)
                        .ToListAsync();
                    _context.StandardFees.RemoveRange(existingFees);

                    // Add new fees
                    var newFees = viewModel.FeeTypes
                        .Where(ft => ft.IsSelected)
                        .Select(ft => new StandardFee
                        {
                            StandardId = id,
                            FeeTypeId = ft.FeeTypeId,
                            Amount = ft.Amount,
                            DueDate = ft.DueDate
                        });

                    await _context.StandardFees.AddRangeAsync(newFees);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandardExists(viewModel.StandardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(viewModel);
        }

        private bool StandardExists(int id)
        {
            return _context.Standards.Any(e => e.UniqueId == id);
        }
    }
}
