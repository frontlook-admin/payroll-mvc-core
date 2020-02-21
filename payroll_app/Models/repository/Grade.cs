using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        [Column("Grade Id")]
        [Display(Name = "Grade Id")]
        public int GradeId { get; set; }

        [Key]
        [MaxLength(30, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("Grade Name")]
        [Display(Name = "Grade Name")]
        [Required]
        public string GradeName { get; set; }

        [Key]
        [MaxLength(30, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("Grade Code")]
        [Display(Name = "Grade Code")]
        [Required]
        public string GradeCode { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}