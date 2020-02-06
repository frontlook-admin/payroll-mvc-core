using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Department")]
    [Display(Name = "Department",Description = "Stores Department Details.")]
    public class Department
    {
        //public IEnumerable<Department> Departments;

        public Department()
        {

        }

        public Department(int departmentId, string departmentName, string departmentCode, string arrangeOrder)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            DepartmentCode = departmentCode;
            ArrangeOrder = arrangeOrder;
        }

        [Key]
        [Column("DepartmentId")]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        [Key]
        [MaxLength(30)]
        [Column("DepartmentName")]
        [Display(Name = "Department Name")]
        [Required]
        public string DepartmentName { get; set; }

        [Key]
        [MaxLength(30)]
        [Column("DepartmentCode")]
        [Display(Name = "Department Code")]
        [Required]
        public string DepartmentCode { get; set; }

        [MaxLength(11)]
        [Column("ArrangeOrder")]
        [Display(Name = "Arrange Order")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        //[Required]
        public string ArrangeOrder { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
