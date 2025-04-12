using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.User
{
    public class Relation
    {
        [Key]
        public int UniqueId { get; set; }
        [Required]
        public string RelationName { get; set; } = string.Empty;
    }
}
