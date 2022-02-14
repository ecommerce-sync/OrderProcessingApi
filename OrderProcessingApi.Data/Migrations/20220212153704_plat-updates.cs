using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class platupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Platform_Type",
                table: "Platforms",
                newName: "PlatformType");

            migrationBuilder.RenameColumn(
                name: "Platform_Sku",
                table: "Platforms",
                newName: "PlatformSku");

            migrationBuilder.RenameColumn(
                name: "Platform_Id",
                table: "Platforms",
                newName: "PlatformId");

            migrationBuilder.AlterColumn<string>(
                name: "PlatformType",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Platforms");

            migrationBuilder.RenameColumn(
                name: "PlatformType",
                table: "Platforms",
                newName: "Platform_Type");

            migrationBuilder.RenameColumn(
                name: "PlatformSku",
                table: "Platforms",
                newName: "Platform_Sku");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Platforms",
                newName: "Platform_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Platform_Type",
                table: "Platforms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
