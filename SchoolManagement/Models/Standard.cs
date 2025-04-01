using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Standard
    {
        [Key]
        public int standardid { get; set; }

        public string classname { get; set; }

        public string classduration { get; set; }

        public decimal amountDue { get; set; }
        public decimal amountPaid { get; set; }

        public DateTime classstartsession { get; set; }

        public DateTime classendsession { get; set; }


        //foreign key concept


        public int sessionid { get; set; }

        public int studentid { get; set; }

        public int feeid { get; set; }



    }
}
