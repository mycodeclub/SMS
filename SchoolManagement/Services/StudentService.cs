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
        public async Task<bool> DeleteStudent(Student student)
        {
            student.IsDeleted = true;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
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

        public Task<List<Student>> GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> SaveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
