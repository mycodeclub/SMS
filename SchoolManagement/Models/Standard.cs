using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Standard
    {
        [Key]
        public int UniqueId { get; set; }

        public string StandardName { get; set; } = string.Empty;


        public int FeeAmountPerMonth { get; set; }

        /// <summary>
        /// The number of months in a billing cycle.
        /// </summary>
        public int BillingCycle { get; set; }

    }
}
