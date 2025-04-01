using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
