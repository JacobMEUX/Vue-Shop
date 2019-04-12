using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedSomeDataAnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_FKCheckoutId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Shipment",
                table: "Costumers");

            migrationBuilder.RenameColumn(
                name: "FKCheckoutId",
                table: "OrderLines",
                newName: "FKOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_FKCheckoutId",
                table: "OrderLines",
                newName: "IX_OrderLines_FKOrderId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Costumers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Costumers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Costumers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Clothing",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Clothing",
                columns: new[] { "ClothingId", "Color", "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { 1, 1, "Sort T-Shirt", 1, 9, 25m, 2, "Sort T-Shirt" });

            migrationBuilder.InsertData(
                table: "Clothing",
                columns: new[] { "ClothingId", "Color", "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { 2, 4, "Grønne bukser", 2, 3, 20m, 1, "Grønne bukser" });

            migrationBuilder.InsertData(
                table: "Clothing",
                columns: new[] { "ClothingId", "Color", "Description", "FKBrandId", "FKCategoryId", "Price", "Size", "Title" },
                values: new object[] { 3, 6, "Gule underbukser", 5, 4, 5m, 3, "Gule underbukser" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_FKOrderId",
                table: "OrderLines",
                column: "FKOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_FKOrderId",
                table: "OrderLines");

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "ClothingId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "FKOrderId",
                table: "OrderLines",
                newName: "FKCheckoutId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_FKOrderId",
                table: "OrderLines",
                newName: "IX_OrderLines_FKCheckoutId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Costumers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Costumers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Costumers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Shipment",
                table: "Costumers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Clothing",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_FKCheckoutId",
                table: "OrderLines",
                column: "FKCheckoutId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
