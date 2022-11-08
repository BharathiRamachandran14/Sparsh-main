using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sparsh.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Transaction_TransactionId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_TransactionId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Cart",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_TransactionId",
                table: "Cart",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Transaction_TransactionId",
                table: "Cart",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Transaction_TransactionId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_TransactionId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Stock",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_TransactionId",
                table: "Stock",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Transaction_TransactionId",
                table: "Stock",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId");
        }
    }
}
