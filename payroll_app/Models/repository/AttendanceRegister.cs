using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace payroll_app.Models.repository
{
    [Table("AttendanceRegister")]
    [Display(Name = "Attendance Register",Description = "Registers Employee Attendance")]
    public class AttendanceRegister
    {

        [Key]
        [Column("Attendance Register Id")]
        [Display(Name = "Attendance Register Id")]
        public int AttendanceRegisterId { get; set; }
        
        [ForeignKey("Id")]
        [Column("Attendance Register Id")]
        [Display(Name = "Attendance Register Id")]
        public int EmployeeId { get; set; }

        public bool Attendance { get; set; }

        [Column("AttendanceTime")]
        [Display(Name = "Attendance Time",AutoGenerateField = true)]
        [DisplayFormat(DataFormatString = "{0:dddd, dd/MM/yyyy, h:mm:ss tt}")]
        //[DisplayFormat(DataFormatString = "{0:dddd, dd/MM/yyyy, h:mm:ss tt}")]
        [Editable(allowEdit:true)]
        [Timestamp]
        public DateTime AttendanceTime { get; set; }

        [ForeignKey("Id")]
        public Employee Employees { get; set; }
    }
}
