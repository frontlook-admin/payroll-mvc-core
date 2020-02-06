using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payroll_app.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(maxLength: 30, nullable: false),
                    DepartmentCode = table.Column<string>(maxLength: 30, nullable: false),
                    ArrangeOrder = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.UniqueConstraint("AK_Department_DepartmentCode", x => x.DepartmentCode);
                    table.UniqueConstraint("AK_Department_DepartmentName", x => x.DepartmentName);
                    table.UniqueConstraint("AK_Department_DepartmentCode_DepartmentId_DepartmentName", x => new { x.DepartmentCode, x.DepartmentId, x.DepartmentName });
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(maxLength: 30, nullable: false),
                    GradeCode = table.Column<string>(maxLength: 30, nullable: false),
                    ArrangeOrder = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                    table.UniqueConstraint("AK_Grade_GradeCode", x => x.GradeCode);
                    table.UniqueConstraint("AK_Grade_GradeName", x => x.GradeName);
                    table.UniqueConstraint("AK_Grade_GradeCode_GradeId_GradeName", x => new { x.GradeCode, x.GradeId, x.GradeName });
                });

            migrationBuilder.CreateTable(
                name: "WorkerType",
                columns: table => new
                {
                    WorkerTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkerTypeName = table.Column<string>(maxLength: 30, nullable: false),
                    WorkerTypeCode = table.Column<string>(maxLength: 30, nullable: false),
                    ArrangeOrder = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerType", x => x.WorkerTypeId);
                    table.UniqueConstraint("AK_WorkerType_WorkerTypeCode", x => x.WorkerTypeCode);
                    table.UniqueConstraint("AK_WorkerType_WorkerTypeName", x => x.WorkerTypeName);
                    table.UniqueConstraint("AK_WorkerType_WorkerTypeCode_WorkerTypeId_WorkerTypeName", x => new { x.WorkerTypeCode, x.WorkerTypeId, x.WorkerTypeName });
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeePhoto = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    FullName = table.Column<string>(maxLength: 700, nullable: true),
                    Gender = table.Column<string>(maxLength: 20, nullable: true),
                    PrimaryMobileNo = table.Column<string>(maxLength: 10, nullable: false),
                    SecondaryMobileNo = table.Column<string>(maxLength: 10, nullable: true),
                    AreaStdCode = table.Column<string>(maxLength: 6, nullable: true),
                    PhoneNo = table.Column<string>(maxLength: 8, nullable: true),
                    EmailId = table.Column<string>(maxLength: 400, nullable: true),
                    Address1 = table.Column<string>(maxLength: 400, nullable: false),
                    Address2 = table.Column<string>(maxLength: 400, nullable: true),
                    Address3 = table.Column<string>(maxLength: 400, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    District = table.Column<string>(maxLength: 100, nullable: true),
                    Pin = table.Column<string>(maxLength: 6, nullable: false),
                    PostOffice = table.Column<string>(maxLength: 100, nullable: false),
                    PoliceStation = table.Column<string>(maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    WorkerTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.UniqueConstraint("AK_Employee_EmailId", x => x.EmailId);
                    table.UniqueConstraint("AK_Employee_PrimaryMobileNo", x => x.PrimaryMobileNo);
                    table.UniqueConstraint("AK_Employee_SecondaryMobileNo", x => x.SecondaryMobileNo);
                    table.UniqueConstraint("AK_Employee_EmailId_Id_PrimaryMobileNo_SecondaryMobileNo", x => new { x.EmailId, x.Id, x.PrimaryMobileNo, x.SecondaryMobileNo });
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_WorkerType_WorkerTypeId",
                        column: x => x.WorkerTypeId,
                        principalTable: "WorkerType",
                        principalColumn: "WorkerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRegister",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    Attendance = table.Column<bool>(nullable: false),
                    AttendanceTime = table.Column<DateTime>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceRegister_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRegister_EmployeeId",
                table: "AttendanceRegister",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GradeId",
                table: "Employee",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkerTypeId",
                table: "Employee",
                column: "WorkerTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceRegister");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "WorkerType");
        }
    }
}
