using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Infrastructure.Migrations
{
    public partial class moredefaultvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Wallets",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 512, DateTimeKind.Local).AddTicks(7321),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 693, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Movements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 514, DateTimeKind.Local).AddTicks(1825),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 695, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_log",
                table: "LogErrors",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 510, DateTimeKind.Local).AddTicks(9291),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 691, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "Incomes",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Incomes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 520, DateTimeKind.Local).AddTicks(6948),
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Wallets",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 693, DateTimeKind.Local).AddTicks(5173),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 512, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Movements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 695, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 514, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_log",
                table: "LogErrors",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 16, 23, 42, 52, 691, DateTimeKind.Local).AddTicks(7690),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 510, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "Incomes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Incomes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 5, 16, 23, 46, 19, 520, DateTimeKind.Local).AddTicks(6948));
        }
    }
}
