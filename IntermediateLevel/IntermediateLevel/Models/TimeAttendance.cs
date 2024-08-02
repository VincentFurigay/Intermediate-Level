using System.ComponentModel.DataAnnotations;

namespace IntermediateLevel.Models
{
    public class TimeAttendance
    {
        [Key]
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Paytype { get; set; }
        public decimal AttDeduction { get; set; }
        public int HoursWorked { get; set; }
        public decimal DailyRate { get; set;}
        public decimal MonthlySalary { get; set; }

    }
}
