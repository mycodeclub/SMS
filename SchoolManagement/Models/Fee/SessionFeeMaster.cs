using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Fee
{
    public class SessionFeeMaster
    {
        [Key]
        public int UniqueId { get; set; }
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionYear Session { get; set; }

     

        public int StandardId { get; set; }
        [ForeignKey(nameof(StandardId))]
        public Standard Standard { get; set; } = default!;

        public decimal AdmissionFee { get; set; }
        public decimal TuitionFee { get; set; }
        public decimal AnnualCharges { get; set; }
        public decimal ActivityFee { get; set; }
        public decimal TransportFee { get; set; }
        public decimal ExaminationFee { get; set; }
        public decimal SportsFee { get; set; }
        public decimal ComputerFee { get; set; }
        public decimal MiscellaneousFee { get; set; }
        [NotMapped]
        public decimal TotalFee =>
    AdmissionFee + TuitionFee + AnnualCharges + ActivityFee +
    TransportFee + ExaminationFee + SportsFee  + ComputerFee + MiscellaneousFee;



    }

}
