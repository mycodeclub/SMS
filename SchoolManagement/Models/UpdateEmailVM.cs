using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class UpdateEmailVM
    {
        [Required]
        [EmailAddress]
        public string NewEmail { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string OldEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
