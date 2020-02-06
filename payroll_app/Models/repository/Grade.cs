using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Grade")]
    [Display(Name = "Grade", Description = "Stores Grade Details.")]
    public class Grade
    {
        public Grade()
        {
            
        }

        public Grade(int gradeId, string gradeName, string gradeCode, string arrangeOrder)
        {
            GradeId = gradeId;
            GradeName = gradeName;
            GradeCode = gradeCode;
            ArrangeOrder = arrangeOrder;
        }

        [Key]
        [Column("GradeId")]
        [Display(Name = "Grade Id")]
        public int GradeId { get; set; }

        [Key]
        [MaxLength(30, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("GradeName")]
        [Display(Name = "Grade Name")]
        [Required]
        public string GradeName { get; set; }

        [Key]
        [MaxLength(30, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("GradeCode")]
        [Display(Name = "Grade Code")]
        [Required]
        public string GradeCode { get; set; }

        [MaxLength(11, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Column("ArrangeOrder")]
        [Display(Name = "Arrange Order")]
        //[Required]
        public string ArrangeOrder { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
