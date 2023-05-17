using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Infrastructure.Migrations
{
    public partial class removerequiredinlogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movements_id_previous_transaction",
                table: "Movements");

            migrationBuilder.AlterColumn<int>(
                name: "id_previous_transaction",
                table: "Movements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_id_previous_transaction",
                table: "Movements",
                column: "id_previous_transaction",
                unique: true,
                filter: "[id_previous_transaction] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movements_id_previous_transaction",
                table: "Movements");

            migrationBuilder.AlterColumn<int>(
                name: "id_previous_transaction",
                table: "Movements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movements_id_previous_transaction",
                table: "Movements",
                column: "id_previous_transaction",
                unique: true);
        }
    }
}
