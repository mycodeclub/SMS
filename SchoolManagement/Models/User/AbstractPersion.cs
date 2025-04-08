using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.User
{
    public abstract class AbstractPersion : AbstractContact
    {
        [Key]
        public int UniqueId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [NotMapped]
        public string Age
        {
            get
            {
                var today = DateTime.Today;

                int years = today.Year - DOB.Year;
                int months = today.Month - DOB.Month;

                if (today.Day < DOB.Day)
                    months--;

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                return $"{years} years, {months} months";
            }
        }
    }
}
