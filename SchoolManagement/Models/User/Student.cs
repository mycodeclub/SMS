using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.User
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public List<ParentOrGeneral>? ParentOrGeneral { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public string? Gender { get; set; }
        public DateTime AdmitionDate { get; set; }

        public int StandardId { get; set; }
        [ForeignKey("StandardId")]
        public Standard? Standard { get; set; }

        public int SessionYearId { get; set; }
        [ForeignKey("SessionYearId")]
        public SessionYear Session { get; set; } = default!;

    }
}
