using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Address
{
    public class Address
    {
        [Key]
        public int UniqueId { get; set; }
        [Required]
        [Display(Name = "Address Line 1 ")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2 ")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "Address Line 3 ")]
        public string? AddressLine3 { get; set; }

        [Display(Name = "Nearest Landmark")]
        public string? NearestLandMark { get; set; }



        [Display(Name = "State")]
        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public State? State { get; set; }




        [Display(Name = "City")]
        public int? CityId { get; set; }

        [ForeignKey("CityId")]
        public City? City { get; set; }



        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }



        [Required]
        [MaxLength(6, ErrorMessage = "Only Six Digits Allowed")]
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
