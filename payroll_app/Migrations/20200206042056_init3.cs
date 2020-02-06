using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payroll_app.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShiftCode = table.Column<string>(nullable: true),
                    ShiftName = table.Column<string>(nullable: true),
                    ShiftTimeIn = table.Column<DateTime>(nullable: false),
                    ShiftTimeOut = table.Column<DateTime>(nullable: false),
                    ShiftTimeSpan = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shift");
        }
    }
}
