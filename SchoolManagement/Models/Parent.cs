using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Parent
    {
             [Key]
            public int parentid { get; set; }   
            public string fullname { get; set; }  
           
            public string relation { get; set; }  
            public string email { get; set; }  
            public string phoneNumber { get; set; }  
            public string address { get; set; }  
            public string occupation { get; set; }  
           
            public string emergencycontact { get; set; }  

            // Foreign Key - One parent can be linked to one or more students
            public int studentId { get; set; }  
            public Student students { get; set; }

      

    }

}
