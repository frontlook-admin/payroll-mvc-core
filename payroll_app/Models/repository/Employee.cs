using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Employee")]
    [Display(Name = "Employee",Description = "Stores Employee Basic Details.")]
    public class Employee
    {
        [Column("Employee Id")]
        [Key]
        public string EmployeeId { get; set; }

        [Column("Employee Photo")]
        [Display(Name = "Employee Photo")]
        public byte[] EmployeePhoto { get; set; }

        [Column("Adult Registration No")]
        [Display(Name = "Adult Registration No")]
        public string AdultRegistrationNo { get; set; }

        [Column("Employee Code")]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }

        [Column("Pf No")]
        [Display(Name = "Pf No")]
        public string PfNo { get; set; }

        [Column("Employee Name")]
        [Display(Name = "Name *")]
        [MaxLength(200, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Required(ErrorMessage = "Employee Name id is required..!!")]
        public string EmployeeName { get; set; }

        [Column("Father Or Husband Name")]
        [Display(Name = "Father/Husband")]
        [MaxLength(200, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string FatherOrHusbandName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        [Column("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("Gender")]
        [Display(Name = "Gender")]
        [MaxLength(20, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string Gender { get; set; }

        [MaxLength(1200, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("Permanent Address")]
        [Display(Name = "Permanent Address")]
        [Required]
        public string PermanentAddress { get; set; }

        [MaxLength(1200, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("Current Address")]
        [Display(Name = "Current Address")]
        [Required]
        public string CurrentAddress { get; set; }

        [Column("Nominee")]
        [Display(Name = "Nominee")]
        [MaxLength(200, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string Nominee { get; set; }

        [Column("Mobile No")]
        [Display(Name = "Mobile No.")]
        [MaxLength(10, ErrorMessage = "Mobile number can not be more than 10 digits..!!")]
        [MinLength(10, ErrorMessage = "Mobile number can not be less than 10 digits..!!")]
        [RegularExpression(@"^[[0-9]{10}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string MobileNo { get; set; }

        [Column("Email Id")]
        [Display(Name = "Email Id.")]
        [MaxLength(400, ErrorMessage = "Exceeded Character Limit..!!")]
        [EmailAddress]
        public string EmailId { get; set; }

        [RegularExpression(@"^[[A-Z]{5}[0-9]{4}[A-Z]{1}]*", ErrorMessage = "Incorrect PAN No...!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string PanNo { get; set; }

        [Column("Aadhar No")]
        [Display(Name = "Aadhar No.")]
        [MaxLength(12, ErrorMessage = "Aadhar number can not be more than 12 digits..!!")]
        [MinLength(12, ErrorMessage = "Aadhar number can not be less than 12 digits..!!")]
        [RegularExpression(@"^[[0-9]{12}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string AadharNo { get; set; }

        [ForeignKey("DepartmentId")]
        public int Department { get; set; }

        [ForeignKey("DesignationId")]
        public int Designation { get; set; }

        [ForeignKey("GradeId")]
        public int Grade { get; set; }

        [ForeignKey("CategoryId")]
        public int Category { get; set; }

        [ForeignKey("ShiftId")]
        public int Shift { get; set; }

        public string OffDay { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Join Date")]
        [Column("Join Date")]
        public DateTime JoinDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:h:mm:sstt}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Working Date")]
        [Column("Last Working Date")]
        public DateTime LastWorkingDate { get; set; }

        public bool Active { get; set; }


        [ForeignKey("Department")]
        public Department Departments { get; set; }
        
        [ForeignKey("Designation")]
        public Designation Designations { get; set; }

        [ForeignKey("Grade")]
        public Grade Grades { get; set; }

        [ForeignKey("Category")]
        public Category Categories { get; set; }
        
        [ForeignKey("Shift")]
        public Shift Shifts{ get; set; }

        public ICollection<AttendanceRegister> AttendanceRegisters { get; set; }
    }
}
