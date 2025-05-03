using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.User
{
    public class Staff : AbstractPersion
    {

        [Display(Name = "Job Role")]
        public required string JobRole { get; set; }

        public int? Experience { get; set; }

        /// <summary>
        /// @ToDo Add Aadhar & photo as well 
        /// </summary>



        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Aadhar")]
        public IFormFile? Aadhar { get; set; }

        public string? AadharFileUrl { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Photos")]
        public IFormFile? Photos { get; set; }

        public string? PhotosFileUrl { get; set; }



        public DateTime DateOfJoin { get; set; } = DateTime.Now;

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        public string? AadhaarNumber { get; set; } = string.Empty;

        public string? Qualification { get; set; } = string.Empty;

    }
}
