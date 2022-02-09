using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class thord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_UserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserGatewayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Integration_User_UserId",
                table: "Integration");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Integration");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserGatewayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserGatewayId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "UserGatewayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Integration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WooIntegrationId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ConsumerKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Integration_Integration_WooIntegrationId",
                        column: x => x.WooIntegrationId,
                        principalTable: "Integration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationId = table.Column<int>(type: "int", nullable: false),
                    Auth0Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Integration_IntegrationId",
                        column: x => x.IntegrationId,
                        principalTable: "Integration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserGatewayId",
                table: "Products",
                column: "UserGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Integration_UserId",
                table: "Integration",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Integration_WooIntegrationId",
                table: "Integration",
                column: "WooIntegrationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IntegrationId",
                table: "User",
                column: "IntegrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserGatewayId",
                table: "Products",
                column: "UserGatewayId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Integration_User_UserId",
                table: "Integration",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
