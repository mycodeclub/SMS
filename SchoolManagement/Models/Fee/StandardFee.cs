using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Fee
{
    public class StandardFee
    {
        [Key]
        public int UniqueId { get; set; }

        [ValidateNever]
        public int? StandardId { get; set; }

        [ForeignKey("StandardId")]
        public Standard Standard { get; set; }

        [ValidateNever]
        public int FeeTypeId { get; set; }
        [ForeignKey("FeeTypeId")]
        public FeeType FeeType { get; set; }

        public decimal Amount { get; set; }

        public DateTime? DueDate { get; set; } // For one-time or custom-dated fees
    }

}
