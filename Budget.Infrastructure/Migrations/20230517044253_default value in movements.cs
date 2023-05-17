using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Infrastructure.Migrations
{
    public partial class defaultvalueinmovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Wallets",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 693, DateTimeKind.Local).AddTicks(5173),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 23, 51, 792, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Movements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 695, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_log",
                table: "LogErrors",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 691, DateTimeKind.Local).AddTicks(7690),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 23, 51, 790, DateTimeKind.Local).AddTicks(8020));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Wallets",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 23, 51, 792, DateTimeKind.Local).AddTicks(1601),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 693, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Movements",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 695, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_log",
                table: "LogErrors",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 23, 51, 790, DateTimeKind.Local).AddTicks(8020),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 691, DateTimeKind.Local).AddTicks(7690));
        }
    }
}
