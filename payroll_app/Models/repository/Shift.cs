using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Shift")]
    [Display(Name = "Shift", Description = "Employee Shift")]
    public class Shift
    {
        
        [Key]
        [Display(Name = "Shift Id")]
        [Column("ShiftId",Order = 0)]
        public int ShiftId { get; set; }

        [Key]
        [Display(Name = "Shift Code")]
        [Column("ShiftCode", Order = 2)]
        public string ShiftCode { get; set; }

        [Key]
        [Display(Name = "Shift Name")]
        [Column("ShiftName", Order = 1)]
        public string ShiftName { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm:sstt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Shift Time In")]
        [Column("ShiftTimeIn")]
        public DateTime ShiftTimeIn { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm:sstt}",ApplyFormatInEditMode = true)]
        [Display(Name = "Shift Time Out")]
        [Column("ShiftTimeOut")]
        public DateTime ShiftTimeOut { get; set; }

        [Display(Name = "Shift Time Span")]
        [Column("ShiftTimeSpan")]
        public TimeSpan TimeSpanz{ get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}