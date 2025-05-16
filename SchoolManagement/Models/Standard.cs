using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Standard
    {
        [Key]
        public int UniqueId { get; set; }

        [Display(Name = "Standard Name")]
        public string StandardName { get; set; } = string.Empty; 
        public int? SessionYearId { get; set; }
        [ForeignKey(nameof(SessionYearId))]
        public SessionYear ?SessionYear { get; set; } 


    }
}
