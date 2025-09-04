using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Dashboard → Standards
        public async Task<IActionResult> Dashboard()
        {
            var standards = await _context.Standards
                .Include(s => s.SessionYear)
                .ToListAsync();

            return View(standards);
        }

        // 2. Subjects by Standard
        public async Task<IActionResult> AttendanceSubject(int standardId)
        {
            var standard = await _context.Standards
                .Include(s => s.SessionYear)
                .FirstOrDefaultAsync(s => s.UniqueId == standardId);

            if (standard == null)
                return NotFound();

            ViewBag.StandardName = standard.StandardName;
            ViewBag.SessionName = standard.SessionYear?.SessionName;

            var subjects = await _context.Subjects
                .Where(s => s.StandardId == standardId)
                .ToListAsync();

            return View(subjects);
        }

        // GET: Mark Attendance
        //[HttpGet]
        //public IActionResult Mark(int standardId, int subjectId, DateTime? date)
        //{
        //    var selectedDate = date ?? DateTime.Today;

        //    // Fetch students for this standard
        //    var students = _context.Students
        //        .Where(s => s.StandardId == standardId)
        //        .Select(s => new AttendanceViewModel
        //        {
        //            StudentId = s.UniqueId,
        //            FullName = s.FullName,
        //            StandardName = s.Standard.StandardName,
        //            SubjectName = _context.Subjects.FirstOrDefault(sub => sub.SubjectId == subjectId).SubjectName,
        //            Date = selectedDate,
        //            AlreadyMarked = _context.StudentAttendances
        //                                .Any(a => a.StudentId == s.UniqueId && a.SubjectId == subjectId && a.Date == selectedDate)
        //        }).ToList();

        //    ViewBag.StandardName = _context.Standards.FirstOrDefault(st => st.UniqueId == standardId)?.StandardName;
        //    ViewBag.SubjectName = _context.Subjects.FirstOrDefault(sub => sub.SubjectId == subjectId)?.SubjectName;
        //    ViewBag.Date = selectedDate;

        //    return View(students);
        //}

        //// POST: Save Attendance
        //[HttpPost]
        //public IActionResult Mark(int standardId, int subjectId, DateTime date, Dictionary<int, bool> attendanceData)
        //{
        //    foreach (var entry in attendanceData)
        //    {
        //        // Skip if already marked
        //        if (_context.StudentAttendances.Any(a => a.StudentId == entry.Key && a.SubjectId == subjectId && a.Date == date))
        //            continue;

        //        var record = new StudentAttendance
        //        {
        //            StudentId = entry.Key,
        //            SubjectId = subjectId,
        //            Date = date,
        //            IsPresent = entry.Value
        //        };
        //        _context.StudentAttendances.Add(record);
        //    }

        //    _context.SaveChanges();

        //    return RedirectToAction("Mark", new { standardId, subjectId, date });
        //}


        //2nd


        public IActionResult Mark(int standardId, int subjectId, DateTime? date)
        {
            var selectedDate = date ?? DateTime.Today;

            // Fetch all students for the standard
            var students = _context.Students
                .Where(s => s.StandardId == standardId)
                .Include(s => s.Standard)
                .ToList();

            // Fetch all attendance records for this subject
            var allAttendance = _context.StudentAttendances
                .Where(a => a.SubjectId == subjectId)
                .ToList();

            // Prepare today's attendance table
            var todayModel = students.Select(s => new AttendanceViewModel
            {
                StudentId = s.UniqueId,
                FullName = s.FullName,
                StandardName = s.Standard.StandardName,
                SubjectName = _context.Subjects.FirstOrDefault(sb => sb.SubjectId == subjectId)?.SubjectName,
                Date = selectedDate,
                AlreadyMarked = allAttendance.Any(a => a.StudentId == s.UniqueId && a.Date.Date == selectedDate.Date),
                IsPresent = allAttendance.FirstOrDefault(a => a.StudentId == s.UniqueId && a.Date.Date == selectedDate.Date)?.IsPresent ?? false
            }).ToList();

            // Prepare report data (all attendance for this subject)
            var reportData = students
                .SelectMany(s => allAttendance
                    .Where(a => a.StudentId == s.UniqueId)
                    .Select(a => new AttendanceViewModel
                    {
                        StudentId = s.UniqueId,
                        FullName = s.FullName,
                        StandardName = s.Standard.StandardName,
                        SubjectName = _context.Subjects.FirstOrDefault(sb => sb.SubjectId == a.SubjectId)?.SubjectName,
                        Date = a.Date,
                        AlreadyMarked = true,
                        IsPresent = a.IsPresent
                    }))
                .OrderBy(r => r.Date)
                .ToList();

            ViewBag.StandardName = _context.Standards.FirstOrDefault(st => st.UniqueId == standardId)?.StandardName;
            ViewBag.SubjectName = _context.Subjects.FirstOrDefault(sb => sb.SubjectId == subjectId)?.SubjectName;
            ViewBag.Date = selectedDate;
            ViewBag.ShowMarkTable = true;
            ViewBag.ReportData = reportData;

            return View(todayModel);
        }


        // POST: Save Attendance
        [HttpPost]
        public IActionResult Mark(int standardId, int subjectId, DateTime date, Dictionary<int, bool> attendanceData)
        {
            if (attendanceData != null)
            {
                foreach (var item in attendanceData)
                {
                    var studentId = item.Key;
                    var isPresent = item.Value;

                    var existing = _context.StudentAttendances
                        .FirstOrDefault(a => a.StudentId == studentId && a.SubjectId == subjectId && a.Date.Date == date.Date);

                    if (existing == null)
                    {
                        _context.StudentAttendances.Add(new StudentAttendance
                        {
                            StudentId = studentId,
                            SubjectId = subjectId,
                            Date = date,
                            IsPresent = isPresent
                        });
                    }
                    else
                    {
                        existing.IsPresent = isPresent;
                        _context.StudentAttendances.Update(existing);
                    }
                }

                _context.SaveChanges();
                TempData["Success"] = "Attendance saved successfully!";
            }

            return RedirectToAction("Mark", new { standardId, subjectId, date });
        }







        // Delete Attendance
        [HttpPost]
            public IActionResult Delete(int id, int standardId, int subjectId, DateTime date)
            {
                var attendance = _context.StudentAttendances.Find(id);
                if (attendance != null)
                {
                    _context.StudentAttendances.Remove(attendance);
                    _context.SaveChanges();
                    TempData["Success"] = "Attendance deleted!";
                }
                return RedirectToAction("Mark", new { standardId, subjectId, date });
            }
   
    [HttpGet]
        public IActionResult AttendanceReport(int standardId, DateTime date)
        {
            // Fetch all attendance for this standard and date
            var students = _context.Students.Where(s => s.StandardId == standardId).ToList();

            var attendances = _context.StudentAttendances
                .Where(a => a.Date == date && students.Select(s => s.UniqueId).Contains(a.StudentId))
                .ToList();

            // Calculate present and absent counts
            var summary = new Dictionary<DateTime, (int Present, int Absent)>();

            int presentCount = attendances.Count(a => a.IsPresent);
            int absentCount = students.Count - presentCount;

            summary[date] = (presentCount, absentCount);

            // Pass to ViewBag to avoid using ViewModel
            ViewBag.AttendanceSummary = summary;
            ViewBag.StandardName = _context.Standards.FirstOrDefault(s => s.UniqueId == standardId)?.StandardName;

            // Fetch students again to display in table
            var attendanceView = students.Select(s => new AttendanceViewModel
            {
                StudentId = s.UniqueId,
                FullName = s.FullName,
                StandardName = s.Standard.StandardName,
                SubjectName = "",
                Date = date,
                AlreadyMarked = attendances.Any(a => a.StudentId == s.UniqueId)
            }).ToList();

            return View("Mark", attendanceView);
        }


        public async Task<IActionResult> Summary()
            {
                var today = DateTime.Today;

                // --- Top Summary ---
                var totalStudents = await _context.Students.CountAsync();
                var todayPresent = await _context.StudentAttendances.CountAsync(a => a.Date == today && a.IsPresent);
                var todayAbsent = await _context.StudentAttendances.CountAsync(a => a.Date == today && !a.IsPresent);

                // --- Pie Chart Data ---
                var pieLabels = new[] { "Present", "Absent" };
                var pieData = new[] { todayPresent, todayAbsent };

                // --- Daily Trend (Last 30 days) ---
                var startDate = today.AddDays(-30);
                var dailyTrendData = await _context.StudentAttendances
                    .Where(a => a.Date >= startDate)
                    .GroupBy(a => a.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        Present = g.Count(a => a.IsPresent),
                        Absent = g.Count(a => !a.IsPresent)
                    })
                    .OrderBy(g => g.Date)
                    .ToListAsync();

                var trendLabels = dailyTrendData.Select(d => d.Date.ToString("dd MMM")).ToList();
                var presentData = dailyTrendData.Select(d => d.Present).ToList();
                var absentData = dailyTrendData.Select(d => d.Absent).ToList();

                // --- Class-wise Summary ---
                var classSummary = await _context.Students
                    .Include(s => s.Standard)
                    .GroupBy(s => s.StandardId)
                    .Select(g => new
                    {
                        Standard = g.First().Standard.StandardName,
                        Total = g.Count(),
                        Present = _context.StudentAttendances.Count(a => a.Date == today && a.Student.StandardId == g.Key && a.IsPresent),
                        Absent = _context.StudentAttendances.Count(a => a.Date == today && a.Student.StandardId == g.Key && !a.IsPresent)
                    })
                    .ToListAsync();

                // --- Monthly Calendar Data ---
                var monthStart = new DateTime(today.Year, today.Month, 1);
                var monthEnd = monthStart.AddMonths(1).AddDays(-1);
                var monthAttendances = await _context.StudentAttendances
                    .Where(a => a.Date >= monthStart && a.Date <= monthEnd)
                    .ToListAsync();

                // --- Students for Search Modal ---
                var allStudents = await _context.Students
                    .Select(s => new { s.UniqueId, s.FullName })
                    .ToListAsync();

                // --- Pass data to ViewBag ---
                ViewBag.TotalStudents = totalStudents;
                ViewBag.TodayPresent = todayPresent;
                ViewBag.TodayAbsent = todayAbsent;
                ViewBag.PieLabels = pieLabels;
                ViewBag.PieData = pieData;
                ViewBag.TrendLabels = trendLabels;
                ViewBag.PresentData = presentData;
                ViewBag.AbsentData = absentData;
                ViewBag.ClassSummary = classSummary;
                ViewBag.MonthAttendances = monthAttendances;
                ViewBag.AllStudents = allStudents;

                return View();
            }
        }
    }


        



