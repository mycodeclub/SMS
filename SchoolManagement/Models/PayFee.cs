namespace SchoolManagement.Models
{
    public class PayFee
    {
        public string UniqueId { get; set; }

        public int AmountPaid {  get; set; }
        public int AmountDue {  get; set; }

        public string PaymentMode {  get; set; }

        public DateTime PaymentDate { get; set; }


    }
}
