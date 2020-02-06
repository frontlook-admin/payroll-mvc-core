using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payroll_app.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employee_EmailId",
                table: "Employee");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employee_SecondaryMobileNo",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryMobileNo",
                table: "Employee",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Employee",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceTime",
                table: "AttendanceRegister",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecondaryMobileNo",
                table: "Employee",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Employee",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceTime",
                table: "AttendanceRegister",
                nullable: true,
                oldClrType: typeof(DateTime))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employee_EmailId",
                table: "Employee",
                column: "EmailId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employee_SecondaryMobileNo",
                table: "Employee",
                column: "SecondaryMobileNo");
        }
    }
}
