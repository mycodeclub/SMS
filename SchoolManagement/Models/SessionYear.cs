using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class SessionYear
    {
        [Key]
        public int UniqueId { get; set; }
        [Display(Name = "Session  Name")]
        public string SessionName { get; set; } = string.Empty;
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
