using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Fee
{
    public class SessionFeeMaster
    {
        [Key]
        public int UniqueId { get; set; }

        [Display(Name ="Fee Type")]
        public string FeeType { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionYear Session { get; set; }
        public int StandardId { get; set; }
    }
}
