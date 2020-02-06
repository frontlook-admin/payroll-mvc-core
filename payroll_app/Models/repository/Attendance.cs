using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace payroll_app.Models.repository
{
    [Table("Attendance")]
    [Display(Name = "Attendance", Description = "Registers Employee Attendance")]
    public class Attendance
    {
        public Attendance()
        {
            
        }

        [Key]
        public int AttendanceId { get; set; }

        [ForeignKey("Id")]
        public int EmployeeId { get; set; }

        [MaxLength(2)]
        public int AttendanceCount { get; set; }

        [Column("Month")]
        [Display(Name = "Month", AutoGenerateField = true)]
        [DisplayFormat(DataFormatString = "{0:MMMM}",ApplyFormatInEditMode = true)]
        public DateTime Month { get; set; }

        [Column("Month")]
        [Display(Name = "Month", AutoGenerateField = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime year { get; set; }

        [ForeignKey("Id")]
        public Employee Employees { get; set; }
    }
}
