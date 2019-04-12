using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RenamedShoppingCartsToOrderLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    FKClothingId = table.Column<int>(nullable: false),
                    FKCheckoutId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => new { x.FKClothingId, x.FKCheckoutId });
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_FKCheckoutId",
                        column: x => x.FKCheckoutId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Clothing_FKClothingId",
                        column: x => x.FKClothingId,
                        principalTable: "Clothing",
                        principalColumn: "ClothingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_FKCheckoutId",
                table: "OrderLines",
                column: "FKCheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    FKClothingId = table.Column<int>(nullable: false),
                    FKCheckoutId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => new { x.FKClothingId, x.FKCheckoutId });
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Orders_FKCheckoutId",
                        column: x => x.FKCheckoutId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Clothing_FKClothingId",
                        column: x => x.FKClothingId,
                        principalTable: "Clothing",
                        principalColumn: "ClothingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FKCheckoutId",
                table: "ShoppingCarts",
                column: "FKCheckoutId");
        }
    }
}
