using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
