using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionFeeController : BaseController
    {
        private readonly AppDbContext _context;

        public SessionFeeController(AppDbContext context, ISessionYearService sessionYearService) : base(sessionYearService)
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
