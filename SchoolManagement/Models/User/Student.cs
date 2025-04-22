using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        [NotMapped]
        public string FullAddress
        {
            get
            {
                StringBuilder _address = new StringBuilder();
                if (HomeAddress != null)
                {
                    if (!string.IsNullOrWhiteSpace(HomeAddress.AddressLine1))
                        _address.Append($"{HomeAddress.AddressLine1} - ");
                    if (!string.IsNullOrWhiteSpace(HomeAddress.AddressLine2))
                        _address.Append($"{HomeAddress.AddressLine2} - ");
                    if (!string.IsNullOrWhiteSpace(HomeAddress.AddressLine3))
                        _address.Append($"{HomeAddress.AddressLine3} - ");
                    if (!string.IsNullOrWhiteSpace(HomeAddress.NearestLandMark))
                        _address.Append($"{HomeAddress.NearestLandMark} - ");

                    if (HomeAddress.State != null && !string.IsNullOrWhiteSpace(HomeAddress.State.Name))
                        _address.Append($"{HomeAddress.State.Name} - ");
                    if (HomeAddress.City != null && !string.IsNullOrWhiteSpace(HomeAddress.City.Name))
                        _address.Append($"{HomeAddress.City.Name} - ");

                    if (!string.IsNullOrWhiteSpace(HomeAddress.PinCode))
                        _address.Append($"{HomeAddress.PinCode}");

                }
                return _address.ToString();
            }
        }


        public int StandardId { get; set; }
        [ForeignKey("StandardId")]
        public Standard? Standard { get; set; }

        public int SessionYearId { get; set; }
        [ForeignKey("SessionYearId")]

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
        public string AadhaarNumber { get; set; } = string.Empty;

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

        public bool IsDeleted { get; set; }

        public SessionYear? Session { get; set; } = default!;
        public DateTime CreatedDate { get; internal set; }
        public DateTime LastUpdatedDate { get; internal set; }
    }
}
