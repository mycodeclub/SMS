using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Contact
    {
        [Key]
         public int Contactid { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


        public string Mobile { get; set; }

        public string descrption { get; set; }
    }
}
