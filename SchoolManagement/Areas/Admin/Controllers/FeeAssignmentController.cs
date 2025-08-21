using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Models.Fee;
using SchoolManagement.Models.User;

namespace SchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeeAssignmentController : Controller
    {
        private readonly AppDbContext _context;

        public FeeAssignmentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ManageFees(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.Standard)
                .Include(s => s.ParentOrGuardians)
                .Include(s => s.HomeAddress)
                .Include(s => s.FeeItems)
                .FirstOrDefaultAsync(s => s.UniqueId == studentId);

            if (student == null)
                return NotFound();

            var standardFees = await _context.StandardFees
                .Where(sf => sf.StandardId == student.StandardId)
                .Include(sf => sf.FeeType)
                .ToListAsync();

            var feeItemsToDisplay = standardFees.Select(sf =>
            {
                var existing = student.FeeItems
                    .Where(f => f.FeeTypeId == sf.FeeTypeId && f.IsPaid == false)
                    .OrderBy(f => f.DueDate)
                    .FirstOrDefault();

                return new StudentFeeItem
                {
                    FeeTypeId = sf.FeeTypeId,
                    FeeTypeName = sf.FeeType.Name,
                    Frequency = sf.FeeType.Frequency.ToString(),
                    Amount = existing?.Amount ?? sf.Amount,
                    DueDate = existing?.DueDate ?? sf.DueDate,
                    IsPaid = existing?.IsPaid ?? false,
                    Month = existing?.Month ?? (sf.FeeType.ApplicableFromMonth > 0 ? GetMonthName(sf.FeeType.ApplicableFromMonth) : null)
                };
            }).ToList();

            ViewBag.FeeItemsForForm = feeItemsToDisplay;

            var savedInstallmentsGrouped = student.FeeItems
                .Where(f => f.IsPaid)
                .OrderBy(f => f.DueDate)
                .GroupBy(f => f.Frequency)
                .ToDictionary(g => g.Key, g => g.ToList());

            ViewBag.SavedInstallmentsGrouped = savedInstallmentsGrouped;

            return View("ManageFees", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageFees(int uniqueId, List<StudentFeeItem> feeItems)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return BadRequest(errors);
            }

            var dbStudent = await _context.Students
                .Include(s => s.FeeItems)
                .FirstOrDefaultAsync(s => s.UniqueId == uniqueId);

            if (dbStudent == null)
                return NotFound();

            foreach (var item in feeItems ?? new List<StudentFeeItem>())
            {
                if (!item.DueDate.HasValue)
                    continue;

                item.Month = GetMonthName(item.DueDate.Value.Month);

                var existing = dbStudent.FeeItems.FirstOrDefault(f =>
                    f.FeeTypeId == item.FeeTypeId &&
                    f.DueDate.HasValue &&
                    f.DueDate.Value.Month == item.DueDate.Value.Month &&
                    f.DueDate.Value.Year == item.DueDate.Value.Year);

                if (existing == null)
                {
                    dbStudent.FeeItems.Add(new StudentFeeItem
                    {
                        StudentId = dbStudent.UniqueId,
                        FeeTypeId = item.FeeTypeId,
                        FeeTypeName = item.FeeTypeName,
                        Frequency = item.Frequency,
                        DueDate = item.DueDate,
                        Month = item.Month,
                        PaidAmount = item.PaidAmount,
                        Amount = item.Amount,
                        DiscountAmount = item.DiscountAmount,
                        PaymentMode = item.PaymentMode,
                        IsPaid = true,
                        CreatedAt = DateTime.Now
                    });
                }
                else
                {
                    existing.Amount = item.Amount;
                    existing.DiscountAmount = item.DiscountAmount;

                    existing.PaymentMode = item.PaymentMode;
                    existing.PaidAmount = item.PaidAmount;
                    existing.IsPaid = true;
                    existing.Month = item.Month;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("ManageFees", new
            {
                studentId = uniqueId,
                activeTab = "saved"
            });
        }



        [HttpPost]
        public async Task<IActionResult> DeleteFeeItem(int studentId, int feeTypeId, DateTime? dueDate)
        {
            var item = await _context.StudentFeeItems
                .Where(f => f.StudentId == studentId && f.FeeTypeId == feeTypeId && f.IsPaid && f.DueDate == dueDate)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                _context.StudentFeeItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ManageFees", new { studentId, activeTab = "saved" });
        }

        private string GetMonthName(int month)
        {
            return (month >= 1 && month <= 12)
                ? new DateTime(2025, month, 1).ToString("MMMM")
                : "Invalid";
        }





        public IActionResult DashBoard()
        {
            var vm = new DashboardVM
            {
                TotalStudents = _context.Students.Count(),

                TotalCollected = _context.StudentFeeItems.Sum(f => f.PaidAmount),
                TotalDiscount = _context.StudentFeeItems.Sum(f => f.DiscountAmount),

                // SQL me direct formula likh diya
                TotalDue = _context.StudentFeeItems.Sum(f => (f.Amount + f.FineAmount) - f.DiscountAmount - f.PaidAmount)

            };


            return View(vm);
        }

        // 🔹 All Students page (row/column = table)
        [HttpGet]


        public IActionResult Students()
        {
            var students = _context.Students
                .Include(s => s.Standard)
                .Include(s => s.FeeItems)
                .Include(s => s.ParentOrGuardians)
                    .ThenInclude(p => p.Relation) // Father, Mother, Guardian
                .AsEnumerable()
                .OrderBy(s => s.FullName)
                .ToList();

            return View(students);
        }


        // Model: IEnumerable<Student>


        // 🔹 Student details for modal (AJAX → JSON)

        [HttpGet]
        public IActionResult GetStudentDetails(int id)
        {
            var student = _context.Students
                .Include(s => s.FeeItems)
                .Include(s => s.ParentOrGuardians)
                    .ThenInclude(p => p.Relation)
                .FirstOrDefault(s => s.UniqueId == id);

            if (student == null) return NotFound();

            var result = new
            {
                totalFees = student.FeeItems?.Sum(f => f.Amount) ?? 0,
                totalDiscount = student.FeeItems?.Sum(f => f.DiscountAmount) ?? 0,
                afterDiscount = (student.FeeItems?.Sum(f => f.Amount) ?? 0) - (student.FeeItems?.Sum(f => f.DiscountAmount) ?? 0),
                paid = student.FeeItems?.Sum(f => f.PaidAmount) ?? 0,
                due = (student.FeeItems?.Sum(f => f.Amount) ?? 0) - (student.FeeItems?.Sum(f => f.PaidAmount) ?? 0),
                feeItems = student.FeeItems?.Select(f => new {
                    f.FeeTypeName,
                    f.Amount
                }),
                parents = student.ParentOrGuardians?.Select(p => new {
                    fullName = p.FullName,
                    aadhaarNumber = p.AadhaarNumber,
                    photosFileUrl = p.PhotosFileUrl,
                    phoneNumber = p.PrimaryPhoneNumber,
                    occupation = p.Occupation,
                    ctc = p.CTC,
                    fullAddress = p.FullAddress,
                    relationName = p.Relation?.RelationName
                })
            };

            return Json(result);
        }

    }

}





