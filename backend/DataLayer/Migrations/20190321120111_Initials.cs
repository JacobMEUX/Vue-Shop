using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Shipment = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Clothing",
                columns: table => new
                {
                    ClothingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    FKBrandId = table.Column<int>(nullable: false),
                    FKCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothing", x => x.ClothingId);
                    table.ForeignKey(
                        name: "FK_Clothing_Brands_FKBrandId",
                        column: x => x.FKBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothing_Categories_FKCategoryId",
                        column: x => x.FKCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FKUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.CheckoutId);
                    table.ForeignKey(
                        name: "FK_Checkouts_User_FKUserId",
                        column: x => x.FKUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_ShoppingCarts_Checkouts_FKCheckoutId",
                        column: x => x.FKCheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "CheckoutId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Clothing_FKClothingId",
                        column: x => x.FKClothingId,
                        principalTable: "Clothing",
                        principalColumn: "ClothingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Ralph Lauren" },
                    { 9, "Adidas" },
                    { 8, "Lacoste" },
                    { 7, "Gucci" },
                    { 6, "Levi Strauss & Co." },
                    { 10, "Versace" },
                    { 4, "Hugo Boss" },
                    { 3, "Nike" },
                    { 2, "Tommy Hilfiger" },
                    { 5, "Burberry" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 8, "Sweaters and waistcoats" },
                    { 1, "Accessories" },
                    { 2, "Jackets and coats" },
                    { 3, "Trousers and shorts" },
                    { 4, "Underwear" },
                    { 5, "Suits" },
                    { 6, "Skirts and dresses" },
                    { 7, "Shoes, boots and slippers" },
                    { 9, "Shirts, t-shirts and tops" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_FKUserId",
                table: "Checkouts",
                column: "FKUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_FKBrandId",
                table: "Clothing",
                column: "FKBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_FKCategoryId",
                table: "Clothing",
                column: "FKCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_FKCheckoutId",
                table: "ShoppingCarts",
                column: "FKCheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Clothing");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
