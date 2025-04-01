using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Sessionofclass
    {
        [Key]
        public int sessionid { get; set; }

        public DateTime sessionstart { get; set; }

        public DateTime sessionend { get; set; }

        public string sessiontype {  get; set; } // online/offline

        public string statusofsession { get; set; }  // complete canceeled like


        //foreign key

        public int studentid { get; set; }
        public Student students { get; set; }

        public int standardid { get; set; }
        public Standard standards { get; set; }


        

           

    }
}
