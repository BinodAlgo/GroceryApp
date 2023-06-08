using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroceryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GroceryItems",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GroceryItems");
        }
    }
}
