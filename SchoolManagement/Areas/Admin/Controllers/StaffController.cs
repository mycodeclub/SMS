using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Controllers;
using SchoolManagement.Data;
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


  
        [HttpGet]
        public async Task<IActionResult> CreateStaff(int id)
        {
            var staff = await _context.Staffs.Where(s => s.UniqueId == id)
                .FirstOrDefaultAsync();
            return View(staff);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStaff(SchoolManagement.Models.User.Staff staff)
        {
            ValidateFileUploads(staff);
            if (ModelState.IsValid)
            {
                if (staff.UniqueId == 0)
                    _context.Staffs.Add(staff);
                {
                    // Existing record - fetch it first
                    var existingStaff = await _context.Staffs.FindAsync(staff.UniqueId);
                    if (existingStaff == null)
                    {
                        return NotFound();
                    }

                    // Update only relevant properties
                    existingStaff.JobRole = staff.JobRole;
                    existingStaff.DateOfJoin = staff.DateOfJoin;
                    existingStaff.Experience = staff.Experience;
                    existingStaff.Qualification = staff.Qualification;
                    existingStaff.FirstName = staff.FirstName;
                    existingStaff.LastName = staff.LastName;
                    existingStaff.DOB = staff.DOB;
                    existingStaff.AadhaarNumber = staff.AadhaarNumber;
                    existingStaff.Email = staff.Email;
                    existingStaff.PrimaryPhoneNumber = staff.PrimaryPhoneNumber;

                    await _context.SaveChangesAsync();
                }

                if (staff.Aadhar != null && staff.Aadhar.Length > 0)
            {
                staff.AadharFileUrl = await Common.CommonFuntions.UploadFile(staff.Aadhar, "staff", staff.UniqueId, "Aadhar");
                await _context.SaveChangesAsync();
            }
            if (staff.Photos != null && staff.Photos.Length > 0)
            {
                staff.PhotosFileUrl = await Common.CommonFuntions.UploadFile(staff.Photos, "staff", staff.UniqueId, "Photos");
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

            return View(staff);
        }

        public async Task<IActionResult> Delete(int? id)
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

        // POST: Staff/Students/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details");
 
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
