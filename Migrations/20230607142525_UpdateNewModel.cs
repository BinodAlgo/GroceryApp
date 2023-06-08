using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Products_ProductId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ProductId",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "GroceryItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryItems_BillId",
                table: "GroceryItems",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItems_Bills_BillId",
                table: "GroceryItems",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItems_Bills_BillId",
                table: "GroceryItems");

            migrationBuilder.DropIndex(
                name: "IX_GroceryItems_BillId",
                table: "GroceryItems");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "GroceryItems");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ProductId",
                table: "Bills",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Products_ProductId",
                table: "Bills",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
