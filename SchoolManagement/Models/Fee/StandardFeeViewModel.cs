using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Fee
{
    public class StandardFeeViewModel
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; } = string.Empty;
        public List<FeeTypeViewModel> FeeTypes { get; set; } = new();
    }

    public class FeeTypeViewModel
    {
        public int FeeTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRecurring { get; set; }
        public int Frequency { get; set; }
        public bool IsOptional { get; set; }
        public int ApplicableFromMonth { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsSelected { get; set; }
    }
}