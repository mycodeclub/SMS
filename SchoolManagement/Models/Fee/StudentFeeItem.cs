using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchoolManagement.Models.User; // for Student reference

namespace SchoolManagement.Models.Fee
{
    public class StudentFeeItem
    {
        [Key]
        public int Id { get; set; }

        public int FeeTypeId { get; set; }

        public string FeeTypeName { get; set; }

        public decimal Amount { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsPaid { get; set; }

        public string Frequency { get; set; }


        public decimal DiscountAmount { get; set; } = 0;
        public decimal FineAmount { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public decimal FinalAmount => (Amount + FineAmount) - DiscountAmount;

        [NotMapped]
        public decimal DueAmount => FinalAmount - PaidAmount;

        [ValidateNever]
        public string Month { get; set; }  // Optional if needed for display

        public string PaymentMode { get; set; } // Cash, Online, Bank Transfer
        [ValidateNever]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [ValidateNever]
        public Student Student { get; set; }

        // Optional: created timestamp
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
