using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models.User;
using System.Threading.Tasks;

namespace SchoolManagement.Services
{
    public class StudentService : IStudentService
    {
        private AppDbContext _context { get; set; }
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
   
        public Task<List<Student>> GetAllStudents()
        {
            return _context.Students.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Student>> GetStudentByStanderd(int standerdId, bool includingParents = false)
        {
            var result = _context.Students.Where(s => s.IsDeleted == false && s.StandardId == standerdId);
            if (includingParents == true)
                result.Include(s => s.ParentOrGuardians);
            return await result.ToListAsync();
        }


        public async Task<Student> SaveStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetStudentById(int id)
        {
            return await _context.Students
                .Where(s => s.UniqueId == id && s.IsDeleted == false)
                .ToListAsync();
        }
        public async Task<bool> DeleteStudent(Student student)
        {
            student.IsDeleted = true;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.UniqueId == id && s.IsDeleted == false);
        }

    }
}
