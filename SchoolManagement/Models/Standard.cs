using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Standard
    {
        [Key]
         public int standardid { get; set; }

         public string classname { get; set; }

         public string classduration { get; set; }

         public int  feeamount { get; set; }
         public DateTime classstartdate { get; set; }

         public DateTime classenddate { get; set; }

        public string sectionofclass { get; set; }

        //foreign key concept


    }
}
