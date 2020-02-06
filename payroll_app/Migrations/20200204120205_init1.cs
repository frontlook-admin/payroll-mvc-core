using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payroll_app.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employee_EmailId_Id_PrimaryMobileNo_SecondaryMobileNo",
                table: "Employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceTime",
                table: "AttendanceRegister",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employee_Id_PrimaryMobileNo",
                table: "Employee",
                columns: new[] { "Id", "PrimaryMobileNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employee_Id_PrimaryMobileNo",
                table: "Employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceTime",
                table: "AttendanceRegister",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employee_EmailId_Id_PrimaryMobileNo_SecondaryMobileNo",
                table: "Employee",
                columns: new[] { "EmailId", "Id", "PrimaryMobileNo", "SecondaryMobileNo" });
        }
    }
}
