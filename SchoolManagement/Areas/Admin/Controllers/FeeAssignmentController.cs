using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
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
            var allStudents = await _context.Students
                .Include(s => s.Standard)
                .Include(s => s.ParentOrGuardians)
                .ToListAsync();

            var student = await _context.Students
                .Include(s => s.Standard)
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

            return View("ManageFees", Tuple.Create<IEnumerable<Student>, Student>(allStudents, student));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageFees(int uniqueId, int standardId, List<StudentFeeItem> feeItems)
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
    }
}
