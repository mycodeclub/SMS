using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class StaffNewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Job Role")]
        public string JobRole { get; set; }

        public int? Experience { get; set; }
        [Display(Name = "Aadhar Number")]
        public string AadhaarNumber { get; set; }

        public int SessionYearId { get; set; }
        [ForeignKey("SessionYearId")]
        public SessionYear SessionYear { get; set; }
        public string Qualification { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        public DateTime DOB { get; set; } = DateTime.Now;

        [NotMapped]
        public string Age
        {
            get
            {
                var today = DateTime.Now;

                int years = today.Year - DOB.Year;
                int months = today.Month - DOB.Month;

                if (today.Day < DOB.Day)
                    months--;

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                return $"{years} Y";
                // return $"{years} Y, {months} M";
            }
        }
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Primary Contact")]
        public string PrimaryPhoneNumber { get; set; } = string.Empty;

    }
}
