using SchoolManagement.Models.User;

namespace SchoolManagement.Models
{

    public class DashboardVM
    {
        public int TotalStudents { get; set; }
        public decimal TotalCollected { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalDiscount { get; set; }
        public List<Student> Students { get; set; } = new(); // ✅ initialize
    }

    public class StudentDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public List<FeeDetailVM> Fees { get; set; } = new();
      
    }

    public class FeeDetailVM
    {
        public string FeeType { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Paid { get; set; }
        public decimal AfterDiscount { get; set; }
    }
}