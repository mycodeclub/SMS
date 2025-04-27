using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.ProcModels
{
    public class SessionDetailsDto
    {
        public int StandardId { get; set; }
        public int SessionId { get; set; }
        public string SessionName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StandardName { get; set; } = string.Empty;
        public int StudentCount { get; set; }


        [Display(Name = "Fee Amout Per Month")]
        public int FeeAmountPerMonth { get; set; }

        /// <summary>
        /// The number of months in a billing cycle.
        /// </summary>
        [Display(Name = "Billing Cycle")]
        public int BillingCycle { get; set; }

    }
}
