using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProcessingApi.Data.Migrations
{
    public partial class addedgatewaynames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BundleProduct");

            migrationBuilder.DropTable(
                name: "PlatformProduct");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "UserGatewayId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_UserGatewayId");

            migrationBuilder.CreateTable(
                name: "BundleGatewayProductGateway",
                columns: table => new
                {
                    BundlesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleGatewayProductGateway", x => new { x.BundlesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_BundleGatewayProductGateway_Bundles_BundlesId",
                        column: x => x.BundlesId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BundleGatewayProductGateway_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatformGatewayProductGateway",
                columns: table => new
                {
                    PlatformsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformGatewayProductGateway", x => new { x.PlatformsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PlatformGatewayProductGateway_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlatformGatewayProductGateway_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleGatewayProductGateway_ProductsId",
                table: "BundleGatewayProductGateway",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGatewayProductGateway_ProductsId",
                table: "PlatformGatewayProductGateway",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserGatewayId",
                table: "Products",
                column: "UserGatewayId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserGatewayId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BundleGatewayProductGateway");

            migrationBuilder.DropTable(
                name: "PlatformGatewayProductGateway");

            migrationBuilder.RenameColumn(
                name: "UserGatewayId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserGatewayId",
                table: "Products",
                newName: "IX_Products_UserId");

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
    }
}
