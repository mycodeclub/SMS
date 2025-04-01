using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class LoginVM
    {
        [NotMapped]
        [Required]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [NotMapped]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
