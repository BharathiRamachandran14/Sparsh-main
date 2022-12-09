using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sparsh.Migrations
{
    public partial class updatedversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_ProductId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Stock",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CartId",
                table: "Stock",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Cart_CartId",
                table: "Stock",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Cart_CartId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_CartId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                newName: "IX_Cart_ProductId");

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");
        }
    }
}
