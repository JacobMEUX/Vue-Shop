using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangedCostumerIdFromIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Costumer_CostumerName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CostumerName",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumer",
                table: "Costumer");

            migrationBuilder.DropColumn(
                name: "CostumerName",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Costumer",
                newName: "Costumers");

            migrationBuilder.AlterColumn<string>(
                name: "FKCostumerId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Costumers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CostumerId",
                table: "Costumers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumers",
                table: "Costumers",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKCostumerId",
                table: "Orders",
                column: "FKCostumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Costumers_FKCostumerId",
                table: "Orders",
                column: "FKCostumerId",
                principalTable: "Costumers",
                principalColumn: "CostumerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Costumers_FKCostumerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FKCostumerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumers",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "CostumerId",
                table: "Costumers");

            migrationBuilder.RenameTable(
                name: "Costumers",
                newName: "Costumer");

            migrationBuilder.AlterColumn<string>(
                name: "FKCostumerId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CostumerName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Costumer",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumer",
                table: "Costumer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CostumerName",
                table: "Orders",
                column: "CostumerName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Costumer_CostumerName",
                table: "Orders",
                column: "CostumerName",
                principalTable: "Costumer",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
