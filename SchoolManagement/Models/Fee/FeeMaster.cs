using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Fee
{
    public class FeeTypeMaster
    {
        [Key]
        public int UniqueId { get; set; }
      
        [Display(Name ="Fee Type")]
        public string FeeType { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
