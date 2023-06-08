using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPaidToBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Bills",
                newName: "GroceryItemId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Bills",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_GroceryItemId",
                table: "Bills",
                column: "GroceryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_GroceryItems_GroceryItemId",
                table: "Bills",
                column: "GroceryItemId",
                principalTable: "GroceryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_GroceryItems_GroceryItemId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_GroceryItemId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "GroceryItemId",
                table: "Bills",
                newName: "ProductId");
        }
    }
}
