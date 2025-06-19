using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
using SchoolManagement.Models.User;
using SchoolManagement.Services;

namespace SchoolManagement.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class StaffController(AppDbContext context, ISessionYearService sessionYearService) : BaseController(sessionYearService)
    {
        private readonly AppDbContext _context = context;

        //GET: Admin/StaffNew
        public async Task<IActionResult> Index()
        {
            var stafflist = await _context.Staffs.ToListAsync();
            ViewBag.ActiveSession = await GetActiveSession();
            return View(stafflist);
        }

        // GET: Admin/StaffNew/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                 .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var staff = _context.Staffs.Find(id); // Your DbSet might be _context.Staff instead
            if (staff == null)
            {
                return Json(new { success = false, error = "Staff member not found." });
            }

            try
            {
                _context.Staffs.Remove(staff);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }




        public async Task<IActionResult> CreateStaff(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new SchoolManagement.Models.User.Staff()); // For Create
            }
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff); // For Edit
        }

        // POST: Create or Edit Staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStaff(SchoolManagement.Models.User.Staff staff)
        {
            if (ModelState.IsValid)
            {
                if (staff.UniqueId == 0)
                {
                    // New staff - Add
                    _context.Add(staff);
                    await _context.SaveChangesAsync(); // Save to get generated UniqueId (if DB generated)
                }
                else
                {
                    // Existing staff - Update
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }

                // Handle file uploads after save (UniqueId should be set now)
                if (staff.Aadhar != null && staff.Aadhar.Length > 0)
                {
                    staff.AadharFileUrl = await Common.CommonFuntions.UploadFile(staff.Aadhar, "staff", staff.UniqueId, "Aadhar");
                }
                if (staff.Photos != null && staff.Photos.Length > 0)
                {
                    staff.PhotosFileUrl = await Common.CommonFuntions.UploadFile(staff.Photos, "staff", staff.UniqueId, "Photos");
                }

                // Save file URL changes
                _context.Update(staff);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(staff);
        }


        // add for photos and adhaar staff

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


        private void ValidateFileUploads(SchoolManagement.Models.User.Staff staff)
        {
            if (staff.Aadhar != null)
            {
                if (staff.Aadhar.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Aadhar", "Aadhaar file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(staff.Aadhar.FileName).ToLower()))
                {
                    ModelState.AddModelError("Aadhar", "Only JPG, JPEG, and PNG formats are allowed for Aadhaar.");
                }
            }

            if (staff.Photos != null)
            {
                if (staff.Photos.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Photos", "Photos file size must not exceed 2 MB.");
                }
                else if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(staff.Photos.FileName).ToLower()))
                {
                    ModelState.AddModelError("Photos", "Only JPG, JPEG, and PNG formats are allowed for Photos.");
                }
            }
        }


    }
}
