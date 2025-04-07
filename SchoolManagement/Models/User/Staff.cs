using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.User
{
    public class Staff : AbstractPersion
    {

        public string JobRole { get; set; } 
        public int? Experience { get; set; }

        /// <summary>
        /// @ToDo Add Aadhar & photo as well 
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
        public string AadhaarNumber { get; set; }

        public string Qualification { get; set; }

    }
}
