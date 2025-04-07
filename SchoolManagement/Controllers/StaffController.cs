using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;

namespace SchoolManagement.Controllers
{
    public class StaffController : Controller
    {

        private readonly Appdbcontext _context;
        public StaffController(Appdbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ContactDetail()
        {
            return View(await _context.Standards.ToListAsync());
        }

    }
}
