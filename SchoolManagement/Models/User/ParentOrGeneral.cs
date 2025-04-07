using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.User
{
    public class ParentOrGeneral : AbstractPersion
    {

        public string RelationWithStudent { get; set; } = string.Empty;

        public Address.Address? HomeAddress { get; set; }
        public string Occupation { get; set; } = string.Empty;
        public int CTC { get; set; }

    }

}
