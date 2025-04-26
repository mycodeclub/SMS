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
using System;
using System.Formats.Tar;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Controllers;
using SchoolManagement.Services;


namespace SchoolManagement.Areas.Staff
{
    [Area("Staff")]
    public class StudentsController : BaseController
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context, ISessionYearService sessionYearService) : base(sessionYearService)
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
            ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            ViewBag.ActiveSession = GetActiveSession();   
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
            .Include(s => s.HomeAddress)
            .ThenInclude(a => a.Country)
            .Include(s => s.HomeAddress)
            .ThenInclude(a => a.State)
            .Include(s => s.HomeAddress)
            .ThenInclude(a => a.City)
             .Include(s => s.ParentOrGuardians).ThenInclude(p => p.Relation)
             .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (student == null)
            {
                return NotFound();
            }

            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName", student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", student.StandardId);
            ViewData["RelationId"] = new SelectList(_context.Relations, "UniqueId", "UniqueId", "StudentUniqueId");
            return View(student);
        }
        // GET: Staff/Students/Create
        public async Task<IActionResult> Create(int id)
        {
            var student = await _context.Students.Include(s => s.ParentOrGuardians).ThenInclude(s => s.Relation).Where(s => s.UniqueId == id).FirstOrDefaultAsync();
            if (student == null)
                student = new Student
                {
                    SessionYearId = 1,
                    DOB = DateTime.Now.AddYears(-2),
                    AdmitionDate = DateTime.Now
                };
            ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "SessionName", student.SessionYearId);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", student.StandardId);
            ViewData["RelationId"] = new SelectList(_context.Relations, "UniqueId", "UniqueId", "StudentUniqueId");
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            ValidateFileUploads(student);
            if (ModelState.IsValid)
            {
                if (student.UniqueId == 0)
                {
                    student.LastUpdatedDate = student.CreatedDate = DateTime.UtcNow;
                    _context.Add(student);

                }
                else
                {
                    student.LastUpdatedDate = DateTime.UtcNow;
                    _context.Update(student);
                }
                await _context.SaveChangesAsync();
                if (student.Aadhar != null && student.Aadhar.Length > 0)
                {
                    student.AadharFileUrl = await Common.CommonFuntions.UploadFile(student.Aadhar, "Student", student.UniqueId, "Aadhar");
                    await _context.SaveChangesAsync();
                }
                if (student.Photos != null && student.Photos.Length > 0)
                {
                    student.PhotosFileUrl = await Common.CommonFuntions.UploadFile(student.Photos, "Student", student.UniqueId, "Photos");
                    await _context.SaveChangesAsync();
                }
                ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
                ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
                ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
                ViewData["SessionYearId"] = new SelectList(_context.SessionYears, "UniqueId", "UniqueId", student.SessionYearId);
                ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "UniqueId", student.StandardId);
                //return RedirectToAction("Edit", student.UniqueId);
                return RedirectToAction("Index");
            }
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

            ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            ViewBag.stuParents = await _context.Parents.Include(r => r.Relation).Where(p => p.StudentUniqueId == parent.StudentUniqueId).ToListAsync();
            ViewBag.RelationId = await _context.Relations.ToListAsync();
            ViewBag.SessionYearId = new SelectList(_context.SessionYears, "UniqueId", "SessionName", 1);

            return View(parent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParents(ParentOrGuardians parent)
        {
            ValidateFileUploads(parent);
            if (ModelState.IsValid)
            {
                if (parent.UniqueId == 0)
                    _context.Parents.Add(parent);
                else
                    _context.Update(parent);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            if (parent.Aadhar != null && parent.Aadhar.Length > 0)
            {
                parent.AadharFileUrl = await Common.CommonFuntions.UploadFile(parent.Aadhar, "Parent", parent.UniqueId, "Aadhar");
                await _context.SaveChangesAsync();
            }
            if (parent.Photos != null && parent.Photos.Length > 0)
            {
                parent.PhotosFileUrl = await Common.CommonFuntions.UploadFile(parent.Photos, "Parent", parent.UniqueId, "Photos");
                await _context.SaveChangesAsync();
            }
            var student = await _context.Students
            .Include(s => s.ParentOrGuardians).ThenInclude(p => p.Relation)
            .FirstOrDefaultAsync(s => s.UniqueId == parent.StudentUniqueId);
            ViewData["CountryId"] = new SelectList(_context.Countrys, "UniqueId", "Name", 1);
            ViewData["StateId"] = new SelectList(_context.States, "UniqueId", "Name", 32);
            ViewData["CityId"] = new SelectList(_context.Cities.Where(c => c.StateId.Equals(32)), "UniqueId", "Name", 1056);
            ViewData["StandardId"] = new SelectList(_context.Standards, "UniqueId", "StandardName", student.StandardId);
            var parents = await _context.Parents.Include(r => r.Relation).Where(p => p.StudentUniqueId == parent.StudentUniqueId).ToListAsync();
            ViewBag.stuParents = parents;
            var _relation = await _context.Relations.ToListAsync();
            ViewBag.RelationId = _relation;
            ViewBag.SessionYearId = new SelectList(_context.SessionYears, "UniqueId", "SessionName", student.SessionYearId);
            return View(parent);
        }

        [HttpGet]



        // GET: ParentOrGuardians/ParentDetail/5
        public async Task<IActionResult> ParentDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentOrGuardian = await _context.Parents
                .Include(p => p.Relation)

                .FirstOrDefaultAsync(m => m.UniqueId == id);

            if (parentOrGuardian == null)
            {
                return NotFound();
            }

            return View(parentOrGuardian);
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
            var parents = await _context.Parents.Include(r => r.Relation).Where(p => p.StudentUniqueId == parent.StudentUniqueId).ToListAsync();
            ViewBag.stuParents = parents;
            var _relation = await _context.Relations.ToListAsync();
            ViewBag.RelationId = _relation;

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
            var parents = await _context.Parents.Include(r => r.Relation).Where(p => p.StudentUniqueId == parent.StudentUniqueId).ToListAsync();
            ViewBag.stuParents = parents;
            var _relation = await _context.Relations.ToListAsync();
            ViewBag.RelationId = _relation;
            return View(parent);
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.UniqueId == id);
        }
        private async Task<(string? AadhaarImagePath, string? PhotoImagePath)> UploadAadhaarAndPhotosImageAsync(IFormFile? aadhaarFile, IFormFile? photoFile)
        {
            string? aadhaarImagePath = null;
            string? photoImagePath = null;


            if (aadhaarFile != null && aadhaarFile.Length > 0)

            {
                var aadhaarFileName = Path.GetFileName(aadhaarFile.FileName);
                var aadhaarFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
                if (!Directory.Exists(aadhaarFilePath))
                    Directory.CreateDirectory(aadhaarFilePath);

                using (var stream = new FileStream(aadhaarFilePath + aadhaarFileName, FileMode.Create))
                    await aadhaarFile.CopyToAsync(stream);

                aadhaarImagePath = "/images/" + aadhaarFileName;
            }

            if (photoFile != null && photoFile.Length > 0)
            {
                var photoFileName = Path.GetFileName(photoFile.FileName);
                var photoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photoFileName);

                using (var stream = new FileStream(photoFilePath, FileMode.Create))
                {
                    await photoFile.CopyToAsync(stream);
                }

                photoImagePath = "/images/" + photoFile;
            }

            return (aadhaarImagePath, photoImagePath);
        }

        private void ValidateFileUploads(ParentOrGuardians parent)
        {
            if (parent.Aadhar != null)
            {
                if (parent.Aadhar.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Aadhar", "Aadhaar file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(parent.Aadhar.FileName).ToLower()))
                {
                    ModelState.AddModelError("Aadhar", "Only JPG, JPEG, and PNG formats are allowed for Aadhaar.");
                }
            }

            if (parent.Photos != null)
            {
                if (parent.Photos.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Photos", "Photos file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(parent.Photos.FileName).ToLower()))
                {
                    ModelState.AddModelError("Photos", "Only JPG, JPEG, and PNG formats are allowed for Photos.");
                }
            }

        }

        // for student photo & Adhaar
        private void ValidateFileUploads(Student student)
        {
            if (student.Aadhar != null)
            {
                if (student.Aadhar.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Aadhar", "Aadhaar file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(student.Aadhar.FileName).ToLower()))
                {
                    ModelState.AddModelError("Aadhar", "Only JPG, JPEG, and PNG formats are allowed for Aadhaar.");
                }
            }

            if (student.Photos != null)
            {
                if (student.Photos.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Photos", "Photos file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(student.Photos.FileName).ToLower()))
                {
                    ModelState.AddModelError("Photos", "Only JPG, JPEG, and PNG formats are allowed for Photos.");
                }
            }
        }

    }
}
