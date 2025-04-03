using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StandardController : Controller
    {
        private readonly Appdbcontext _context;
        public StandardController(Appdbcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  IActionResult Standardadd() //create
        {
            return View();
        }
        [HttpPost]
        public IActionResult Standardadd(Standard standard)
        {
            if (ModelState.IsValid)
            {
                // Save to the database
                _context.Add(standard);
                _context.SaveChanges();

                // Set success message in TempData
                TempData["SuccessMessage"] = "Standard created successfully!";
                return RedirectToAction(nameof(Detail));
            }

            // If something went wrong, set an error message
            TempData["ErrorMessage"] = "There was an issue creating the standard.";
            return View(standard);
        }


        public async Task<IActionResult> Detail()
        {
            return View(await _context.standards.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var standard = await _context.standards.FindAsync(id);
            if (standard == null)
            {
                return NotFound();
            }
            return View(standard);
        }

        // UPDATE - Edit an existing Standard
        [HttpPost]
        public async Task<IActionResult> Edit(int standardid, Standard standard)
        {
            if (standardid!= standard.standardid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(standard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standard);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int standardid)
        {
            var standard = await _context.standards.FindAsync(standardid);
            if (standard == null)
            {
                return NotFound();
            }
            return View(standard);
        }

        
        [HttpPost]
       
        public async Task<IActionResult> DeleteConfirmed(int standardid)
        {
            var standard = await _context.standards.FindAsync(standardid);
            if (standard != null)
            {
                _context.standards.Remove(standard);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Detail)); // Redirect to Index after deleting
        }
    }
}

