using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;

namespace SchoolManagement.Areas.Admin.Controllers
{
  
    [Area("Admin")]
    public class SessionFeeController : Controller
     {
     private readonly AppDbContext _context;

    public SessionFeeController(AppDbContext context)
    {
                _context = context;
    }
            public IActionResult Index()
        {
            return View();
        }

        public IActionResult SessionFee()
        {
            return View();
        }

    }
}
