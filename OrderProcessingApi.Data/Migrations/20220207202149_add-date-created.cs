using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class adddatecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last_Modified",
                table: "Users",
                newName: "Date_Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Last_Modified",
                table: "Products",
                newName: "Date_Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Last_Modified",
                table: "Platforms",
                newName: "Date_Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Last_Modified",
                table: "Bundles",
                newName: "Date_Last_Modified");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "Platforms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "Bundles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Bundles");

            migrationBuilder.RenameColumn(
                name: "Date_Last_Modified",
                table: "Users",
                newName: "Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Date_Last_Modified",
                table: "Products",
                newName: "Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Date_Last_Modified",
                table: "Platforms",
                newName: "Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Date_Last_Modified",
                table: "Bundles",
                newName: "Last_Modified");
        }
    }
}
