using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Column("Department Id")]
        public int DepartmentId { get; set; }

        [Column("Department Name")]
        public string DepartmentName { get; set; }

        [Column("Department Code")]
        public string DepartmentCode { get; set; }

        [Column("Department Formula")]
        public string DepartmentFormula { get; set; }

        [NotMapped]
        [Column("Arrange Order")]
        public int ArrangeOrder { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}