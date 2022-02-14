using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class adjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Integrations_UserId",
                table: "Integrations");

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_UserId",
                table: "Integrations",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Integrations_UserId",
                table: "Integrations");

            migrationBuilder.CreateIndex(
                name: "IX_Integrations_UserId",
                table: "Integrations",
                column: "UserId");
        }
    }
}
