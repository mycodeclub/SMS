using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolManagement.Models
{
  
public class AppUser:IdentityUser
    {


   



        [Required]
        [EmailAddress]

        [Display(Name = " Enter Your Email")]

        public string Email { get; set; }




        [Required]
        [Phone]
        [Display(Name = " Enter Phone Number")]
        public string PhoneNumber { get; set; }


        [NotMapped]
        [Display(Name = " Create Your  Password")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Display(Name = " Confirm Your Password")]
        public string ConfirmPassword { get; set; }



    }



}

