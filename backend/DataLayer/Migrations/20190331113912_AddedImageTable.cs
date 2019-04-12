using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FKImageId",
                table: "Clothing",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "AltText", "Url" },
                values: new object[] { 1, "Polo Ralph Lauren", "https://admin.kaufmannstatic.com/Images/158260_sort_01-T20190211074923.jpg?i=158260_sort_01-T20190211074923.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "AltText", "Url" },
                values: new object[] { 2, "Grønne bukser", "http://www.maconresidence.eu/images/large/tommy-hilfiger/Nyt%20K%C3%B8b%20Tommy%20Hilfiger%20Gr%C3%B8nne%20Blandet%20Blend%20Bukser%20til%20B%C3%B8rn%20Outlet%20187_LRG.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "AltText", "Url" },
                values: new object[] { 3, "Gule underbukser", "https://www.fashionhero.dk/shared/9/9520a88e8980e6334a8ab327cd4b710b_h940w940_min.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 1,
                columns: new[] { "Description", "FKImageId", "Title" },
                values: new object[] { "Polo Ralph Lauren", 1, "Polo Ralph Lauren" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 2,
                column: "FKImageId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 3,
                columns: new[] { "FKBrandId", "FKImageId" },
                values: new object[] { 4, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_FKImageId",
                table: "Clothing",
                column: "FKImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothing_Images_FKImageId",
                table: "Clothing",
                column: "FKImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothing_Images_FKImageId",
                table: "Clothing");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Clothing_FKImageId",
                table: "Clothing");

            migrationBuilder.DropColumn(
                name: "FKImageId",
                table: "Clothing");

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Sort T-Shirt", "Sort T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 3,
                column: "FKBrandId",
                value: 5);
        }
    }
}
