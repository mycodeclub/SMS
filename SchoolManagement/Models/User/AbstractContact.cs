using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.User
{
    public class AbstractContact
    {
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Primary Contact ")]
        public string PrimaryPhoneNumber { get; set; } = string.Empty;
        [Display(Name = "Secondry Contact")]
        public string SecondryPhoneNumber { get; set; } = string.Empty;

    }
}
