using Microsoft.Identity.Client;
using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class StudentFee
    {
        [Key]
        public int UniqueId { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; } = default!;
        public int Month { get; set; }
        public int SubmittedFeesAmount { get; set; }
        public DateTime SubmittedDate { get; set; }

        public int AnnulyFee { get; set; }

        public int  Quarentely { get; set;}

        public int HalfYearly { get; set; }



    }
}
