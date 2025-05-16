using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Fee
{
    public class FeeType
    {
        [Key]
        public int FeeTypeId { get; set; }
        public string Name { get; set; } = string.Empty;    // e.g. "Tuition Fee", "Lohri Celebration"
        public bool IsRecurring { get; set; } = false;  // Recurring or one-time
        public int Frequency { get; set; }      // number of months
        public int DueDate { get; set; }    // Due date for the fee payment
        public bool IsOptional { get; set; } = false;   // Optional for selected students
        public int ApplicableFromMonth { get; set; }    // Due date for the fee payment
    }

}
