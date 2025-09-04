using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
   
        public class StudentAttendance
        {
          [Key]
           public int UniqueId { get; set; }
            public DateTime Date { get; set; }
            public bool IsPresent { get; set; }
            public string? Remarks { get; set; }

            // Student relation
            public int StudentId { get; set; }
            public Student Student { get; set; }

            // Subject relation
            public int SubjectId { get; set; }
            public Subject Subject { get; set; }
    }

}
