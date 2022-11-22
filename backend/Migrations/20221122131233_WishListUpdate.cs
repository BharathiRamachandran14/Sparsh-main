using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sparsh.Migrations
{
    public partial class WishListUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Wishlist",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Users_UserId",
                table: "Wishlist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Users_UserId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wishlist");
        }
    }
}
