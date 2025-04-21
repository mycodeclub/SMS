using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Staff
{
    [Area("Staff")]
    public class StandardsController : Controller
    {
        [Obsolete]
        private readonly AppDbContext _context;
        private readonly IStudentService _studentService;

        public StandardsController(IStudentService studentService , AppDbContext context)
        {
              _context = context;
            _studentService = studentService;
        }

        // GET: Staff/Standards
        public async Task<IActionResult> Index()
        {
            var students = await _context.Standards.ToListAsync();
            return View(students);
        }

        // GET: Staff/Standards/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(standard);
        }

        // GET: Staff/Standards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Standards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniqueId,StandardName,FeeAmountPerMonth,BillingCycle")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standard);
        }

        // GET: Staff/Standards/Edit/5
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
            return View(standard);
        }

        // POST: Staff/Standards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,StandardName,FeeAmountPerMonth,BillingCycle")] Standard standard)
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
            return View(standard);
        }

        // GET: Staff/Standards/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(standard);
        }

        // POST: Staff/Standards/Delete/5
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

        private bool StandardExists(int id)
        {
            return _context.Standards.Any(e => e.UniqueId == id);
        }
    }
}
