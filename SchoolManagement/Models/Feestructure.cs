using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Feestructure
    {
        [Key]
        public int feeid { get; set; }

        public int classfeeofmonthly { get; set; }

        public int totalfeeclass { get; set; }

        public int discountfee { get; set; }

        public int feeafterdiscount { get;set;}

        public int feebeforediscount { get; set; }


        public int paidfee {  get; set; }
      

        public int duefee {  get; set; }


        public DateTime datesubmissionoffee {  get; set; }

        public string statusoffee {  get; set; }


        //foreign key

        public int studentid { get; set; }
        public int standardId { get; set; }
       
        


    }
}
