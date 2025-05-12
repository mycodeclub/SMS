using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Fee
{
    public class SessionFeeMaster
    {
        [Key]
        public int UniqueId { get; set; }

        public int StudentFeeId { get; set; }
        [ForeignKey(nameof(StudentFeeId))]
        public StudentFee StudentFee { get; set; } = default!;

        public int StandardId { get; set; }
        [ForeignKey(nameof(StandardId))]
        public Standard Standard { get; set; } = default!;
    }

}
