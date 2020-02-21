using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        [Column("Designation Id")]
        [Display(Name = "Designation Id")]
        public int DesignationId { get; set; }

        [Column("Designation Name")]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        [Column("Designation Code")]
        [Display(Name = "Designation Code")]
        public string DesignationCode { get; set; }

        [Column("Designation Formula")]
        [Display(Name = "Designation Formula")]
        public string DesignationFormula { get; set; }

        [NotMapped]
        [Column("Arrange Order")]
        [Display(Name = "Arrange Order")]
        public int ArrangeOrder { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}