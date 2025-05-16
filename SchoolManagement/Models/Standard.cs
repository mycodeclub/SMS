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

        [Obsolete]
        [Display(Name = "Fee Amout Per Month")]
        public int FeeAmountPerMonth { get; set; }

        /// <summary>
        /// The number of months in a billing cycle.
        /// </summary>

        [Obsolete]
        [Display(Name = "Billing Cycle")]
        public int BillingCycle { get; set; }


        public int? SessionYearId { get; set; }
        [ForeignKey(nameof(SessionYearId))]
        public SessionYear ?SessionYear { get; set; } 


    }
}
