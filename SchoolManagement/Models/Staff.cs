using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Staff : AbstractPersion
    {
        [Display(Name = "Job Role")]
        public string JobRole { get; set; }
 
        public int? Experience { get; set; }

        /// <summary>
        /// @ToDo Add Aadhar & photo as well 
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
       
        public string AadhaarNumber { get; set; }
       

        public int SessionYearId { get; set; }
        [ForeignKey("SessionYearId")]
        public SessionYear SessionYear { get; set; }
        public string Qualification { get; set; }

    }
}
