using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class platformtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Platform_Type",
                table: "Platforms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform_Type",
                table: "Platforms");
        }
    }
}
