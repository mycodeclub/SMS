﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.Address
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int UniqueId { get; set; }
        public int StateId { get; set; }
        public string  Name { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
    }
}
