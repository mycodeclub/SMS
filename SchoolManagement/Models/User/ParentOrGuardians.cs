using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        public string Occupation { get; set; } = string.Empty;
        public int CTC { get; set; }
        [NotMapped]
        public bool AddressSameAsStudent { get; set; }

    }

}
