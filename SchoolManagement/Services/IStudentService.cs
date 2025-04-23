using SchoolManagement.Models.User;

namespace SchoolManagement.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudents();
        public Task<List<Student>> GetStudentByStanderd(int standerdId, bool includingParents);
        public Task<List<Student>> GetStudentById(int id);
        public Task<Student> SaveStudent(Student student);
        public Task<bool> DeleteStudent(Student student);
        public Task<bool> UpdateStudent(Student student);
        public Task<Student> GetStudent(int id);

    }
}
