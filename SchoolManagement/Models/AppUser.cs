using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
  
public class AppUser:IdentityUser
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = " Enter Full Name")]
        public string FullName { get; set; }

      
        [Required]
        [EmailAddress]

        [Display(Name = " Enter Your Email")]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = " Enter your Gender")]
        public string Gender { get; set; }


        [Required]
        [Phone]
        [Display(Name = " Enter Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = " Enter Father Name")]
        public string Fathername { get; set; }



        [Required]
        [Display(Name = " Enter Mother Name")]
        public string mothername { get; set; }


        [Required]
        [Display(Name = " Enter Address")]
        public string Address { get; set; }

        // Optionally, add other fields like gender, course, etc.

        [Required]
        [Display(Name = " Create Your  Password")]
        public string Password { get; set; }


        [Required]
        [Display(Name = " Confirm Your Password")]
        public string confirmPassword { get; set; }



    }



}

