using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.Address;
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
                    .Include(s => s.ParentOrGuardians).ThenInclude(p => p.Relation)
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
                .Include(s => s.ParentOrGuardians).ThenInclude(p => p.Relation)
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
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName", student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", student.StandardId);
            ViewData["RelationId"] = new SelectList(_context.Relations, "UniqueId", "UniqueId", "StudentUniqueId");
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
            return RedirectToAction("Edit", student.UniqueId);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                 var student = await _context.Students
                .Include(s => s.Session)
                .Include(s => s.Standard)
                .Include(s => s.ParentOrGuardians).ThenInclude(p => p.Relation)
                .FirstOrDefaultAsync(m => m.UniqueId == id);

            if (student == null)
            {
                return NotFound();
            }
            // Load dropdowns if needed
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", student.StandardId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(e => e.UniqueId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName", student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", student.StandardId);
            return View(student);
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
        [HttpGet]
        public async Task<IActionResult> AddParents(int studentId, int parentId)
        {
            var parent = await _context.Parents.Where(p => p.UniqueId == parentId).FirstOrDefaultAsync();
            if (parent == null)
                parent = new ParentOrGuardians() { StudentUniqueId = studentId };
            ViewBag.stuParents = await _context.Parents.Include(r => r.Relation).Where(p => p.StudentUniqueId == studentId).ToListAsync();
            ViewBag.RelationId = await _context.Relations.ToListAsync();
            ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            return View(parent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParents(ParentOrGuardians parent)
        {

            if (ModelState.IsValid)
            {
                if (parent.UniqueId == 0)
                    _context.Parents.Add(parent);
                else

                    _context.Update(parent);

                await _context.SaveChangesAsync();
            }

            // for reload a student view

            var student = await _context.Students
          .Include(s => s.ParentOrGuardians).ThenInclude(p => p.Relation)
          .FirstOrDefaultAsync(s => s.UniqueId == parent.StudentUniqueId);

            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId",student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", student.StandardId);
            ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            ViewBag.stuParents = await _context.Parents.Include(r => r.Relation).Where(p => p.StudentUniqueId == parent.StudentUniqueId).ToListAsync();
            ViewBag.RelationId = await _context.Relations.ToListAsync();
              return View(parent);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteParents(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var parent = await _context.Parents
                .Include(s => s.Relation)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (parent == null)
            {
                return NotFound();
            }

            return View(parent);

        }

        [HttpPost, ActionName("DeleteParents")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent != null)
            {
                _context.Parents.Remove(parent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(parent);
        }
      

    }
}
