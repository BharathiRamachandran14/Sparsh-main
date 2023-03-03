using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sparsh.Migrations
{
    public partial class CartItemupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartQuantity",
                table: "CartItem",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItem",
                newName: "CartQuantity");
        }
    }
}
