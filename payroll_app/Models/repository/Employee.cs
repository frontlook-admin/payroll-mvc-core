using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace payroll_app.Models.repository
{
    [Table("Employee")]
    [Display(Name = "Employee",Description = "Stores Employee Basic Details.")]
    public class Employee
    {
        public Employee()
        {
            
        }
        // ReSharper disable once RedundantAssignment
        public Employee(byte[] employeePhoto, string firstName, string middleName, string lastName, string fullName,
            string gender, string primaryMobileNo, string secondaryMobileNo, string areaStdCode, string phoneNo,
            string emailId, string address1, string address2, string address3, string city, string district, string pin,
            string postOffice, string policeStation)
        {
            EmployeePhoto = employeePhoto;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            if (!(string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName)) &&
                (string.IsNullOrEmpty(MiddleName) || string.IsNullOrWhiteSpace(MiddleName)) &&
                (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName)))
            {
                fullName = FirstName;
            }
            else if (!(string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName)) &&
                     (string.IsNullOrEmpty(MiddleName) || string.IsNullOrWhiteSpace(MiddleName)) &&
                     !(string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName)))
            {
                fullName = FirstName + " " + LastName;
            }
            else if (!(string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName)) &&
                     !(string.IsNullOrEmpty(MiddleName) || string.IsNullOrWhiteSpace(MiddleName)) &&
                     (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName)))
            {
                fullName = FirstName + " " + MiddleName;
            }
            else
            {
                fullName = FirstName + " " + MiddleName + " " + LastName;
            }

            FullName = fullName;
            Gender = gender;
            PrimaryMobileNo = primaryMobileNo;
            SecondaryMobileNo = secondaryMobileNo;
            AreaStdCode = areaStdCode;
            PhoneNo = phoneNo;
            EmailId = emailId;
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            City = city;
            District = district;
            Pin = pin;
            PostOffice = postOffice;
            PoliceStation = policeStation;
        }

        [Key]
        [Column("Id", Order = 0)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("EmployeePhoto", Order = 1)]
        [Display(Name = "Employee Photo")]
        public byte[] EmployeePhoto { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name *")]
        [MaxLength(200, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Required(ErrorMessage = "First Name id is required..!!")]
        public string FirstName { get; set; }

        [Column("MiddleName")]
        [Display(Name = "Middle Name")]
        [MaxLength(200, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string MiddleName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [MaxLength(200, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string LastName { get; set; }
        
        [MaxLength(700, ErrorMessage = "Exceeded Character Limit..!!")]
        [Column("FullName",Order = 2)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Column("Gender")]
        [Display(Name = "Gender *")]
        [MaxLength(20, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string Gender { get; set; }

        [Key]
        [Column("PrimaryMobileNo", Order = 3)]
        [Display(Name = "Primary Mobile No. *")]
        [MaxLength(10, ErrorMessage = "Mobile number can not be more than 10 digits..!!")]
        [MinLength(10, ErrorMessage = "Mobile number can not be less than 10 digits..!!")]
        [RegularExpression(@"^[[\d]{10}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Required]
        public string PrimaryMobileNo { get; set; }

        [Column("SecondaryMobileNo", Order = 4)]
        [Display(Name = "Secondary Mobile No.")]
        [MaxLength(10, ErrorMessage = "Mobile number can not be more than 10 digits..!!")]
        [MinLength(10, ErrorMessage = "Mobile number can not be less than 10 digits..!!")]
        [RegularExpression(@"^[[\d]{10}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string SecondaryMobileNo { get; set; }

        [Column("AreaStdCode")]
        [Display(Name = "Area Std Code.")]
        [MaxLength(6, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[\d]{6}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string AreaStdCode { get; set; }

        [Column("PhoneNo")]
        [Display(Name = "Phone No.")]
        [MaxLength(8, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[\d]{8}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        public string PhoneNo { get; set; }

        [Column("EmailId", Order = 5)]
        [Display(Name = "Email Id.")]
        [MaxLength(400, ErrorMessage = "Exceeded Character Limit..!!")]
        public string EmailId { get; set; }

        [Column("Address1")]
        [Display(Name = "Address *")]
        [MaxLength(400, ErrorMessage = "Exceeded Character Limit..!!")]
        [Required]
        public string Address1 { get; set; }

        [Column("Address2")]
        [Display(Name = "Address")]
        [MaxLength(400, ErrorMessage = "Exceeded Character Limit..!!")]
        public string Address2 { get; set; }

        [Column("Address3")]
        [Display(Name = "Address")]
        [MaxLength(400, ErrorMessage = "Exceeded Character Limit..!!")]
        public string Address3 { get; set; }

        [Column("City")]
        [Display(Name = "City *")]
        [MaxLength(100, ErrorMessage = "Exceeded Character Limit..!!")]
        [Required]
        public string City { get; set; }

        [Column("District")]
        [Display(Name = "District")]
        [MaxLength(100, ErrorMessage = "Exceeded Character Limit..!!")]
        public string District { get; set; }

        [Column("Pin")]
        [Display(Name = "Pin *")]
        [MaxLength(6, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[\d]{6}]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Required]
        public string Pin { get; set; }

        [Column("PostOffice")]
        [Display(Name = "Post Office *")]
        [MaxLength(100, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only characters..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Required]
        public string PostOffice { get; set; }

        [Column("PoliceStation")]
        [Display(Name = "Police Station *")]
        [MaxLength(100, ErrorMessage = "Exceeded Character Limit..!!")]
        [RegularExpression(@"^[[A-Za-z+[\s]+[A-Za-z]+]*]*", ErrorMessage = "Can accept only digits..!!",
            MatchTimeoutInMilliseconds = 1000)]
        [Required]
        public string PoliceStation { get; set; }
        
        [ForeignKey("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("GradeId")]
        [Required]
        public int GradeId { get; set; }

        [ForeignKey("WorkerTypeId")]
        [Required]
        public int WorkerTypeId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        [ForeignKey("WorkerTypeId")]
        public WorkerType WorkerType { get; set; }

        public ICollection<AttendanceRegister> AttendanceRegisters { get; set; }
    }
}
