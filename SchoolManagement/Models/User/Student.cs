using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.User
{
    public class Student
    {
        [Key]
        public int UniqueId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public List<ParentOrGuardians>? ParentOrGuardians { get; set; }
        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        public string? Gender { get; set; }
        [Display(Name = "Admission Date")]
        public DateTime AdmitionDate { get; set; }

        public Address.Address? HomeAddress { get; set; }
        public int StandardId { get; set; }
        [ForeignKey("StandardId")]
        public Standard? Standard { get; set; }

        public int SessionYearId { get; set; }
        [ForeignKey("SessionYearId")]
        public SessionYear? Session { get; set; } = default!;

    }
}
