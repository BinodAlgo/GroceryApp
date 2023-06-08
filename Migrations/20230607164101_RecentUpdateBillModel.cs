using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RecentUpdateBillModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItems_Bills_BillId",
                table: "GroceryItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "GroceryItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItems_Bills_BillId",
                table: "GroceryItems",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItems_Bills_BillId",
                table: "GroceryItems");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "GroceryItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItems_Bills_BillId",
                table: "GroceryItems",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }
    }
}
