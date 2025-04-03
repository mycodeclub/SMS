using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Student
    {
        [Key]
         public int studentid { get; set; }
        
        public string fullname { get; set; }

        public string emailaddress { get; set; }
        public string phonenumber { get; set; }

        public DateTime dob { get; set; }

        public string gender { get; set; }
        public string fathername { get; set; }

        public string mothername { get; set;}

       
        public string classname { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }


        public string country { get; set; }


        public int pin_code { get; set; }


        public DateTime dateofenroll { get; set; }


        //foreign key

        public int standardid { get; set; }
        public Standard Standard { get; set; }

    }
}
