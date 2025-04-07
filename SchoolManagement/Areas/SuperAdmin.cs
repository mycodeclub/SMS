using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Areas
{
    public class SuperAdmin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
