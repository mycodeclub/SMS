using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Staff
    {
        [Key]
        public int staffId { get; set; }
        public string fullName { get; set; }

        public string JobRole { get; set; }
        public string email { get; set; }
        public DateTime dateOfbirth { get; set; }
        public string phoneNumber { get; set; }
        public int? experience { get; set; }
        public string address { get; set; }

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
        public string aadhaarNumber { get; set; }

        public string qualification { get; set; }

    }
}
