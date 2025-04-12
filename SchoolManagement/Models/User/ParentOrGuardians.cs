using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.User
{
    public class ParentOrGuardians : AbstractPersion
    {
        [Display(Name = "Relation With Student")]
        public int RelationId { get; set; }

        [ForeignKey("RelationId")]
        public Relation? Relation { get; set; }

        public Address.Address? HomeAddress { get; set; }
        public string Occupation { get; set; } = string.Empty;
        public int CTC { get; set; }

    }

}
