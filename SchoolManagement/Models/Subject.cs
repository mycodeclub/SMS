using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SchoolManagement.Models
{
    public class Subject
    {

         [Key]
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }

        // Foreign Key → Standard
        [ValidateNever]
        public int StandardId { get; set; }

            [ForeignKey("StandardId")]
        [ValidateNever]
        public Standard Standards { get; set; }
        }
    }

