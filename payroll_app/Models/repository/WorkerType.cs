using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("WorkerType")]
    [Display(Name = "Worker Type", Description = "Stores Worker Type Details.")]
    public class WorkerType
    {
        //public IEnumerable<WorkerType> WorkerTypes;

        public WorkerType()
        {
            
        }
        public WorkerType(int workerTypeId, string workerTypeName, string workerTypeCode, string arrangeOrder)
        {
            WorkerTypeId = workerTypeId;
            WorkerTypeName = workerTypeName;
            WorkerTypeCode = workerTypeCode;
            ArrangeOrder = arrangeOrder;
        }

        [Key]
        [Column("WorkerTypeId")]
        [Display(Name = "Worker Type Id")]
        public int WorkerTypeId { get; set; }

        [Key]
        [MaxLength(30, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("WorkerTypeName")]
        [Display(Name = "Worker Type Name")]
        [Required]
        public string WorkerTypeName { get; set; }

        [Key]
        [MaxLength(30, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("WorkerTypeCode")]
        [Display(Name = "Worker Type Code")]
        [Required]
        public string WorkerTypeCode { get; set; }

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
