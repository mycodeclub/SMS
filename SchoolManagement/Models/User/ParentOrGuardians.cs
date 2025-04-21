using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.User
{
    public class ParentOrGuardians : AbstractPersion
    {
        [Display(Name = "Relation With Student")]
        public int RelationId { get; set; }

        [ForeignKey("RelationId")]
        public Relation? Relation { get; set; }

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
        public string AadhaarNumber { get; set; } = string.Empty;


        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PA" +
           "N number. Format should be: XXXXX1234X.")]
        [Display(Name = "Pan Num.")]
        public string? PanNumber { get; set; } = string.Empty;


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


        [NotMapped]
        [Display(Name = "Upload Pan")]
        public IFormFile? Pan { get; set; }
        public string? PanFileUrl { get; set; }


        public Address.Address? HomeAddress { get; set; }
        public string Occupation { get; set; } = string.Empty;
        public int CTC { get; set; }

    }

}
