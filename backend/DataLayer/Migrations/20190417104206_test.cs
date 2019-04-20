using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
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
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    CostumerId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.CostumerId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AltText = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FKCostumerId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Costumers_FKCostumerId",
                        column: x => x.FKCostumerId,
                        principalTable: "Costumers",
                        principalColumn: "CostumerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clothing",
                columns: table => new
                {
                    ClothingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    FKBrandId = table.Column<int>(nullable: false),
                    FKCategoryId = table.Column<int>(nullable: false),
                    FKImageId = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Clothing_Images_FKImageId",
                        column: x => x.FKImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    FKClothingId = table.Column<int>(nullable: false),
                    FKOrderId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => new { x.FKClothingId, x.FKOrderId });
                    table.ForeignKey(
                        name: "FK_OrderLines_Clothing_FKClothingId",
                        column: x => x.FKClothingId,
                        principalTable: "Clothing",
                        principalColumn: "ClothingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_FKOrderId",
                        column: x => x.FKOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Ralph Lauren" },
                    { 2, "Tommy Hilfiger" },
                    { 3, "Nike" },
                    { 4, "Hugo Boss" },
                    { 5, "Burberry" },
                    { 6, "Levi Strauss & Co." },
                    { 7, "Gucci" },
                    { 8, "Lacoste" },
                    { 9, "Adidas" },
                    { 10, "Versace" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 9, "T-Shirts" },
                    { 8, "Sweaters and hoodies" },
                    { 7, "Shoes" },
                    { 6, "Skirts and dresses" },
                    { 4, "Underwear" },
                    { 3, "Trousers" },
                    { 2, "Jackets" },
                    { 1, "Accessories" },
                    { 5, "Suits" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "AltText", "Url" },
                values: new object[,]
                {
                    { 8, "Blå Hugo Boss Underbukser", "Images/BlåHugoBossUnderbukser.jpg" },
                    { 1, "Sort Ralph Lauren Polo", "Images/SortRalphLaurenPolo.jpg" },
                    { 2, "Grøn Ralph Lauren Polo", "Images/GrønRalphLaurenPolo.jpg" },
                    { 3, "Rød Ralph Lauren Polo", "Images/RødRalphLaurenPolo.jpg" },
                    { 4, "Blå Ralph Lauren Polo", "Images/BlåRalphLaurenPolo.jpg" },
                    { 5, "Gule Hugo Boss Underbukser", "Images/GuleHugoBossUnderbukser.jpg" },
                    { 6, "Hvide Hugo Boss Underbukser", "Images/HvideHugoBossUnderbukser.jpg" },
                    { 7, "Røde Hugo Boss Underbukser", "Images/RødeHugoBossUnderbukser.jpg" },
                    { 9, "Tommy Hilfinger Bukser", "Images/GrønneTommyHilfingerBukser.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Clothing",
                columns: new[] { "ClothingId", "Color", "Description", "FKBrandId", "FKCategoryId", "FKImageId", "Price", "Size", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Sort Ralph Lauren Polo", 1, 9, 1, 25m, 2, "Sort Ralph Lauren Polo" },
                    { 2, 4, "Grøn Ralph Lauren Polo", 1, 9, 2, 25m, 2, "Grøn Ralph Lauren Polo" },
                    { 3, 3, "Rød Ralph Lauren Polo", 1, 9, 3, 25m, 2, "Rød Ralph Lauren Polo" },
                    { 4, 5, "Blå Ralph Lauren Polo", 1, 9, 4, 25m, 2, "Blå Ralph Lauren Polo" },
                    { 5, 6, "Gule Hugo Boss Underbukser", 4, 4, 5, 5m, 3, "Gule Hugo Boss Underbukser" },
                    { 6, 2, "Hvide Hugo Boss Underbukser", 4, 4, 6, 5m, 3, "Hvide Hugo Boss Underbukser" },
                    { 7, 3, "Røde Hugo Boss Underbukser", 4, 4, 7, 5m, 3, "Røde Hugo Boss Underbukser" },
                    { 8, 5, "Blå Hugo Boss Underbukser", 4, 4, 8, 5m, 3, "Blå Hugo Boss Underbukser" },
                    { 9, 4, "Grønne bukser", 2, 3, 9, 20m, 1, "Tommy Hilfinger Bukser" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_FKBrandId",
                table: "Clothing",
                column: "FKBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_FKCategoryId",
                table: "Clothing",
                column: "FKCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_FKImageId",
                table: "Clothing",
                column: "FKImageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_FKOrderId",
                table: "OrderLines",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKCostumerId",
                table: "Orders",
                column: "FKCostumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Clothing");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Costumers");
        }
    }
}
