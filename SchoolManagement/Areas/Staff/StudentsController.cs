using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models.User;

namespace SchoolManagement.Areas.Staff
{
    [Area("Staff")]
    public class StudentsController : Controller
    {
        private readonly Appdbcontext _context;

        public StudentsController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Staff/Students
        public async Task<IActionResult> Index(int id = 1)
        {
            List<Student> students;
            if (id > 0)
                students = await _context.Students
                    .Include(s => s.Session)
                    .Include(s => s.Standard)
                    .Include(s => s.ParentOrGuardians)
                    .Where(s => s.StandardId == id).ToListAsync();
            else students = await _context.Students
             .Include(s => s.Session)
             .Include(s => s.Standard)
             .Include(s => s.ParentOrGuardians).ToListAsync();
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", id);

            return View(students);
        }

        // GET: Staff/Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .Include(s => s.ParentOrGuardians)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Staff/Students/Create
        public async Task<IActionResult> Create(int id)
        {
            var student = await _context.Students.Include(s => s.ParentOrGuardians).Where(s => s.UniqueId == id).FirstOrDefaultAsync();
            if (student == null)
                student = new Student
                {
                    SessionYearId = 1,
                    DOB = DateTime.Now.AddYears(-2),
                    AdmitionDate = DateTime.Now
                };
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName");
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName");
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", student.StandardId);
            return RedirectToAction("Create", student.UniqueId);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .Include(s => s.ParentOrGuardians)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Staff/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ---------------------------------- Parents 

        public async Task<IActionResult> AddParents(int studentId, int parentId)
        {
            var parent = await _context.Parents.Where(p => p.UniqueId == parentId).FirstOrDefaultAsync();
            if (parent == null)
                parent = new ParentOrGuardians() { StudentUniqueId = studentId };
            ViewData["RelationId"] = new SelectList(_context.Relations, "UniqueId", "RelationName", parent.RelationId);
            return View(parent);
        }

        [HttpPost]
        public IActionResult AddParents(ParentOrGuardians parent)
        {
            // save to db & redirect to student Details.
            return View();
        }

    }
}
