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
        public IActionResult Standardadd() //create
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
                return RedirectToAction(nameof(Details));
            }

            // If something went wrong, set an error message
            TempData["ErrorMessage"] = "There was an issue creating the standard.";
            return View(standard);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return View(await _context.standards.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Details(int standardid)
        {
            var standard = await _context.standards.FindAsync(standardid);
            if (standard == null)
            {
                return NotFound();
            }
            return View(standard);
        }

        public IActionResult Edit()
        {
            return View();
        }






    }
}
        



