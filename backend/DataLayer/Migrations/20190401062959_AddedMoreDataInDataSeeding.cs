using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedMoreDataInDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Jackets");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Trousers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Name",
                value: "Shoes");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "Name",
                value: "Sweaters and hoodies");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "Name",
                value: "T-Shirts");

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Sort Ralph Lauren Polo", "Sort Ralph Lauren Polo" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 2,
                columns: new[] { "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { "Grøn Ralph Lauren Polo", 1, 9, 25m, 2, "Grøn Ralph Lauren Polo" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 3,
                columns: new[] { "Color", "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { 3, "Rød Ralph Lauren Polo", 1, 9, 25m, 2, "Rød Ralph Lauren Polo" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "AltText", "Url" },
                values: new object[] { "Sort Ralph Lauren Polo", "Images/SortRalphLaurenPolo.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "AltText", "Url" },
                values: new object[] { "Grøn Ralph Lauren Polo", "Images/GrønRalphLaurenPolo.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                columns: new[] { "AltText", "Url" },
                values: new object[] { "Rød Ralph Lauren Polo", "Images/RødRalphLaurenPolo.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "AltText", "Url" },
                values: new object[,]
                {
                    { 4, "Blå Ralph Lauren Polo", "Images/BlåRalphLaurenPolo.jpg" },
                    { 5, "Gule Hugo Boss Underbukser", "Images/GuleHugoBossUnderbukser.jpg" },
                    { 6, "Hvide Hugo Boss Underbukser", "Images/HvideHugoBossUnderbukser.jpg" },
                    { 7, "Røde Hugo Boss Underbukser", "Images/RødeHugoBossUnderbukser.jpg" },
                    { 8, "Blå Hugo Boss Underbukser", "Images/BlåHugoBossUnderbukser.jpg" },
                    { 9, "Tommy Hilfinger Bukser", "Images/GrønneTommyHilfingerBukser.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Clothing",
                columns: new[] { "ClothingId", "Color", "Description", "FKBrandId", "FKCategoryId", "FKImageId", "Price", "Size", "Title" },
                values: new object[,]
                {
                    { 4, 5, "Blå Ralph Lauren Polo", 1, 9, 4, 25m, 2, "Blå Ralph Lauren Polo" },
                    { 5, 6, "Gule Hugo Boss Underbukser", 4, 4, 5, 5m, 3, "Gule Hugo Boss Underbukser" },
                    { 6, 2, "Hvide Hugo Boss Underbukser", 4, 4, 6, 5m, 3, "Hvide Hugo Boss Underbukser" },
                    { 7, 3, "Røde Hugo Boss Underbukser", 4, 4, 7, 5m, 3, "Røde Hugo Boss Underbukser" },
                    { 8, 5, "Blå Hugo Boss Underbukser", 4, 4, 8, 5m, 3, "Blå Hugo Boss Underbukser" },
                    { 9, 4, "Grønne bukser", 2, 3, 9, 20m, 1, "Tommy Hilfinger Bukser" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Jackets and coats");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Trousers and shorts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Name",
                value: "Shoes, boots and slippers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "Name",
                value: "Sweaters and waistcoats");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "Name",
                value: "Shirts, t-shirts and tops");

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Polo Ralph Lauren", "Polo Ralph Lauren" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 2,
                columns: new[] { "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { "Grønne bukser", 2, 3, 20m, 1, "Grønne bukser" });

            migrationBuilder.UpdateData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 3,
                columns: new[] { "Color", "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { 6, "Gule underbukser", 4, 4, 5m, 3, "Gule underbukser" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "AltText", "Url" },
                values: new object[] { "Polo Ralph Lauren", "https://admin.kaufmannstatic.com/Images/158260_sort_01-T20190211074923.jpg?i=158260_sort_01-T20190211074923.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "AltText", "Url" },
                values: new object[] { "Grønne bukser", "http://www.maconresidence.eu/images/large/tommy-hilfiger/Nyt%20K%C3%B8b%20Tommy%20Hilfiger%20Gr%C3%B8nne%20Blandet%20Blend%20Bukser%20til%20B%C3%B8rn%20Outlet%20187_LRG.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                columns: new[] { "AltText", "Url" },
                values: new object[] { "Gule underbukser", "https://www.fashionhero.dk/shared/9/9520a88e8980e6334a8ab327cd4b710b_h940w940_min.jpg" });
        }
    }
}
