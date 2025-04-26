using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SchoolManagement.Models
{
    public class SessionYear
    {
        [Key]
        public int UniqueId { get; set; }
        [Display(Name = "Session  Name")]
        public string SessionName { get; set; } = string.Empty;
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public bool IsAcitve { get; set; }
        public List<string> MonthsInSession
        {
            get


            {
                var months = new List<string>();
                var current = new DateTime(StartDate.Year, StartDate.Month, 1);

                var end = new DateTime(EndDate.Year, EndDate.Month, 1);

                while (current <= end)
                {
                    months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(current.Month));
                    current = current.AddMonths(1);
                }
                return months;
            }
        }

        [NotMapped]
        public string SessionDuration
        {
            get
            {
                return $"{StartDate.ToString("dd/MM/yyyy")} - {EndDate.ToString("dd/MM/yyyy")}";
            }
        }
        [NotMapped]

        public string SessionDurationInMonth
        {
            get
            {
                return $"{(EndDate.Year - StartDate.Year) * 12 + EndDate.Month - StartDate.Month} Months";
            }
        }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; }  
        public DateTime UpdatedDate { get; set; }

    }
}