using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    public class Category
    {
        [Key]
        [Column("Category Id")]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Column("Category Name")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Column("Category Code")]
        [Display(Name = "Category Code")]
        public string CategoryCode { get; set; }

        [Column("Category Formula")]
        [Display(Name = "Category Formula")]
        public string CategoryFormula { get; set; }

        [Column("Arrange Order")]
        [Display(Name = "Arrange Order")]
        [NotMapped]
        public int ArrangeOrder { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}