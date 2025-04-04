using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Appdbcontext _dbContext;
        public HomeController(ILogger<HomeController> logger,Appdbcontext appdbcontext)
        {
            _logger = logger;
            _dbContext = appdbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Classes()
        {
            return View();
        }


        public IActionResult Contact() //create
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact c)
        {
            if (ModelState.IsValid)
            {
                // Save to the database
                _dbContext.Add(c);
                _dbContext.SaveChanges();

                // Set success message in TempData
                TempData["SuccessMessage"] = "Contact created successfully!";
                return View(c);
            }

            // If something went wrong, set an error message
            TempData["ErrorMessage"] = "There was an issue creating the standard.";
            return View(c);

        }


        public IActionResult Facility()
        {
            return View();
        }



        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Testimonial()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
