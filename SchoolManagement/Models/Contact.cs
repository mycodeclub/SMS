using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Contact
    {
        [Key]
            public int ContactId { get; set; } 
            public string FullName { get; set; } 
            public string Email { get; set; } 
            public string PhoneNumber { get; set; } 
            public string Message { get; set; } 

    
        

    }
}
