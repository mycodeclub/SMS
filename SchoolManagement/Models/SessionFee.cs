﻿using SchoolManagement.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class SessionFee
    {
        [Key]
        public int UniqueId { get; set; }
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public SessionYear Session { get; set; }


        [Obsolete]
        public int? StandardId { get; set; }
        //        [ForeignKey(nameof(StandardId))]
        [Obsolete]
        public Standard? Standard { get; set; } = default!;

        public decimal AdmissionFee { get; set; }
        public decimal TuitionFee { get; set; }
        public decimal AnnualCharges { get; set; }
        public decimal ActivityFee { get; set; }
        public decimal TransportFee { get; set; }
        public decimal ExaminationFee { get; set; }
        public decimal SportsFee { get; set; }
        public decimal ComputerFee { get; set; }
        public decimal MiscellaneousFee { get; set; }





        [Display(Name = "Fee Type")]
        public string FeeType { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

    }
}