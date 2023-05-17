using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Infrastructure.Migrations
{
    public partial class addingmorefieldstologtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Method",
                table: "LogErrors",
                newName: "method");

            migrationBuilder.RenameColumn(
                name: "Layer",
                table: "LogErrors",
                newName: "layer");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "LogErrors",
                newName: "key");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "LogErrors",
                newName: "data");

            migrationBuilder.RenameColumn(
                name: "DateLog",
                table: "LogErrors",
                newName: "data_log");

            migrationBuilder.RenameColumn(
                name: "Trace",
                table: "LogErrors",
                newName: "stack_trace");

            migrationBuilder.AlterColumn<string>(
                name: "method",
                table: "LogErrors",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "layer",
                table: "LogErrors",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "LogErrors",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_log",
                table: "LogErrors",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "inner_exception",
                table: "LogErrors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "message_error",
                table: "LogErrors",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inner_exception",
                table: "LogErrors");

            migrationBuilder.DropColumn(
                name: "message_error",
                table: "LogErrors");

            migrationBuilder.RenameColumn(
                name: "method",
                table: "LogErrors",
                newName: "Method");

            migrationBuilder.RenameColumn(
                name: "layer",
                table: "LogErrors",
                newName: "Layer");

            migrationBuilder.RenameColumn(
                name: "key",
                table: "LogErrors",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "LogErrors",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "data_log",
                table: "LogErrors",
                newName: "DateLog");

            migrationBuilder.RenameColumn(
                name: "stack_trace",
                table: "LogErrors",
                newName: "Trace");

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "LogErrors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<int>(
                name: "Layer",
                table: "LogErrors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "LogErrors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLog",
                table: "LogErrors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
