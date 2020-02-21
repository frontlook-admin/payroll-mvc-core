using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payroll_app.Migrations
{
    public partial class init00001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(name: "Category Id", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(name: "Category Name", nullable: false),
                    CategoryCode = table.Column<string>(name: "Category Code", nullable: false),
                    CategoryFormula = table.Column<string>(name: "Category Formula", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.UniqueConstraint("AK_Category_Category Code", x => x.CategoryCode);
                    table.UniqueConstraint("AK_Category_Category Name", x => x.CategoryName);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(name: "Department Id", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(name: "Department Name", nullable: false),
                    DepartmentCode = table.Column<string>(name: "Department Code", nullable: false),
                    DepartmentFormula = table.Column<string>(name: "Department Formula", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.UniqueConstraint("AK_Department_Department Code", x => x.DepartmentCode);
                    table.UniqueConstraint("AK_Department_Department Name", x => x.DepartmentName);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(name: "Designation Id", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DesignationName = table.Column<string>(name: "Designation Name", nullable: false),
                    DesignationCode = table.Column<string>(name: "Designation Code", nullable: false),
                    DesignationFormula = table.Column<string>(name: "Designation Formula", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationId);
                    table.UniqueConstraint("AK_Designation_Designation Code", x => x.DesignationCode);
                    table.UniqueConstraint("AK_Designation_Designation Name", x => x.DesignationName);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(name: "Grade Id", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(name: "Grade Name", maxLength: 30, nullable: false),
                    GradeCode = table.Column<string>(name: "Grade Code", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                    table.UniqueConstraint("AK_Grade_Grade Code", x => x.GradeCode);
                    table.UniqueConstraint("AK_Grade_Grade Name", x => x.GradeName);
                    table.UniqueConstraint("AK_Grade_Grade Code_Grade Id_Grade Name", x => new { x.GradeCode, x.GradeId, x.GradeName });
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShiftCode = table.Column<string>(nullable: false),
                    ShiftName = table.Column<string>(nullable: false),
                    ShiftTimeIn = table.Column<DateTime>(nullable: false),
                    ShiftTimeOut = table.Column<DateTime>(nullable: false),
                    ShiftTimeSpan = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                    table.UniqueConstraint("AK_Shift_ShiftCode", x => x.ShiftCode);
                    table.UniqueConstraint("AK_Shift_ShiftName", x => x.ShiftName);
                    table.UniqueConstraint("AK_Shift_ShiftCode_ShiftId_ShiftName", x => new { x.ShiftCode, x.ShiftId, x.ShiftName });
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(name: "Employee Id", nullable: false),
                    EmployeePhoto = table.Column<byte[]>(name: "Employee Photo", nullable: true),
                    AdultRegistrationNo = table.Column<string>(name: "Adult Registration No", nullable: true),
                    EmployeeCode = table.Column<string>(name: "Employee Code", nullable: true),
                    PfNo = table.Column<string>(name: "Pf No", nullable: true),
                    EmployeeName = table.Column<string>(name: "Employee Name", maxLength: 200, nullable: false),
                    FatherOrHusbandName = table.Column<string>(name: "Father Or Husband Name", maxLength: 200, nullable: true),
                    DateOfBirth = table.Column<DateTime>(name: "Date Of Birth", nullable: false),
                    Gender = table.Column<string>(maxLength: 20, nullable: true),
                    PermanentAddress = table.Column<string>(name: "Permanent Address", maxLength: 1200, nullable: false),
                    CurrentAddress = table.Column<string>(name: "Current Address", maxLength: 1200, nullable: false),
                    Nominee = table.Column<string>(maxLength: 200, nullable: true),
                    MobileNo = table.Column<string>(name: "Mobile No", maxLength: 10, nullable: true),
                    EmailId = table.Column<string>(name: "Email Id", maxLength: 400, nullable: true),
                    PanNo = table.Column<string>(nullable: true),
                    AadharNo = table.Column<string>(name: "Aadhar No", maxLength: 12, nullable: false),
                    Department = table.Column<int>(nullable: false),
                    Designation = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Shift = table.Column<int>(nullable: false),
                    OffDay = table.Column<string>(nullable: true),
                    JoinDate = table.Column<DateTime>(name: "Join Date", nullable: false),
                    LastWorkingDate = table.Column<DateTime>(name: "Last Working Date", nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.UniqueConstraint("AK_Employee_Aadhar No", x => x.AadharNo);
                    table.UniqueConstraint("AK_Employee_Employee Name", x => x.EmployeeName);
                    table.ForeignKey(
                        name: "FK_Employee_Category_Category",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "Category Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Department_Department",
                        column: x => x.Department,
                        principalTable: "Department",
                        principalColumn: "Department Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Designation_Designation",
                        column: x => x.Designation,
                        principalTable: "Designation",
                        principalColumn: "Designation Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Grade_Grade",
                        column: x => x.Grade,
                        principalTable: "Grade",
                        principalColumn: "Grade Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Shift_Shift",
                        column: x => x.Shift,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRegister",
                columns: table => new
                {
                    AttendanceRegisterId = table.Column<int>(name: "Attendance Register Id", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Attendance = table.Column<bool>(nullable: false),
                    AttendanceTime = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRegister", x => x.AttendanceRegisterId);
                    table.ForeignKey(
                        name: "FK_AttendanceRegister_Employee_Id",
                        column: x => x.Id,
                        principalTable: "Employee",
                        principalColumn: "Employee Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRegister_Id",
                table: "AttendanceRegister",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Category",
                table: "Employee",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Department",
                table: "Employee",
                column: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Designation",
                table: "Employee",
                column: "Designation");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Grade",
                table: "Employee",
                column: "Grade");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Shift",
                table: "Employee",
                column: "Shift");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceRegister");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Shift");
        }
    }
}
