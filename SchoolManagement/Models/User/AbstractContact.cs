using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.User
{
    public class AbstractContact
    {
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Primary Phone Number")]
        public string PrimaryPhoneNumber { get; set; } = string.Empty;
        [Display(Name = "Secondry Phone Number")]
        public string SecondryPhoneNumber { get; set; } = string.Empty;

    }
}
