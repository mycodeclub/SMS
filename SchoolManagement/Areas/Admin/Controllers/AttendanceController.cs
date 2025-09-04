using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AttendanceController : Controller
    {

      
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }


       public IActionResult AttendanceReport(DateTime? fromDate, DateTime? toDate, int? standardId, int? subjectId)
{
    ViewBag.Standards = _context.Standards.ToList();
    ViewBag.Subjects = _context.Subjects.ToList();

    // pass the current filter values so the view can keep them selected
    ViewBag.FilterFromDate = fromDate?.ToString("yyyy-MM-dd");
    ViewBag.FilterToDate = toDate?.ToString("yyyy-MM-dd");
    ViewBag.FilterStandardId = standardId;
    ViewBag.FilterSubjectId = subjectId;

    List<StudentAttendance> data = null;

    if (fromDate.HasValue || toDate.HasValue || (standardId.HasValue && standardId > 0) || (subjectId.HasValue && subjectId > 0))
    {
        var query = _context.StudentAttendances
            .Include(a => a.Student).ThenInclude(s => s.Standard)
            .Include(a => a.Subject)
            .AsQueryable();

        if (fromDate.HasValue)
            query = query.Where(a => a.Date >= fromDate.Value);
        if (toDate.HasValue)
            query = query.Where(a => a.Date <= toDate.Value);
        if (standardId.HasValue && standardId > 0)
            query = query.Where(a => a.Student.StandardId == standardId.Value);
        if (subjectId.HasValue && subjectId > 0)
            query = query.Where(a => a.SubjectId == subjectId.Value);

        data = query.ToList();

        ViewBag.TotalPresent = data.Count(a => a.IsPresent && a.Remarks != "Leave");
        ViewBag.TotalAbsent = data.Count(a => !a.IsPresent && a.Remarks != "Leave");
        ViewBag.TotalLeave = data.Count(a => a.Remarks == "Leave");
        ViewBag.TotalRecords = data.Count();
    }

    return View(data);
}



    }


}



