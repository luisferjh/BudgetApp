using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Infrastructure.Migrations
{
    public partial class creationusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogErrors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLog = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErrors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.IdState);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar50 = table.Column<string>(name: "nvarchar(50)", type: "nvarchar(max)", nullable: false),
                    dni_type = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogErrors");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
