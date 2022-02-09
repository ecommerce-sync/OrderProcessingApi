using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Users",
                newName: "Last_Modified");

            migrationBuilder.RenameColumn(
                name: "Auth0Id",
                table: "Users",
                newName: "Auth0_Id");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Products",
                newName: "Last_Modified");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BundleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Last_Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform_Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BundleProduct",
                columns: table => new
                {
                    BundlesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleProduct", x => new { x.BundlesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_BundleProduct_Bundles_BundlesId",
                        column: x => x.BundlesId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BundleProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatformProduct",
                columns: table => new
                {
                    PlatformsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformProduct", x => new { x.PlatformsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PlatformProduct_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlatformProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleProduct_ProductsId",
                table: "BundleProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformProduct_ProductsId",
                table: "PlatformProduct",
                column: "ProductsId");

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

            migrationBuilder.DropTable(
                name: "BundleProduct");

            migrationBuilder.DropTable(
                name: "PlatformProduct");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.RenameColumn(
                name: "Last_Modified",
                table: "Users",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "Auth0_Id",
                table: "Users",
                newName: "Auth0Id");

            migrationBuilder.RenameColumn(
                name: "Last_Modified",
                table: "Products",
                newName: "LastModified");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
