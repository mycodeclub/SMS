namespace SchoolManagement.Models
{
    public class AttendanceViewModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string StandardName { get; set; }
        public string SubjectName { get; set; }
        public DateTime Date { get; set; }
        public bool AlreadyMarked { get; set; }

        public bool IsPresent { get; set; }

    }
}
