using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Persistence.Migrations
{
    public partial class initproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2023, 6, 4, 18, 16, 32, 788, DateTimeKind.Local).AddTicks(8977)),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    SURNAME = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2023, 6, 4, 18, 16, 32, 789, DateTimeKind.Local).AddTicks(1052)),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
