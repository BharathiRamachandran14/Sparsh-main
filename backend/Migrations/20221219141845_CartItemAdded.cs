using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sparsh.Migrations
{
    public partial class CartItemAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "StockQuantity",
                table: "Stock",
                newName: "Quantity");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemProductId = table.Column<int>(type: "integer", nullable: true),
                    CartQuantity = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    CartId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ItemProductId",
                        column: x => x.ItemProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ItemProductId",
                table: "CartItem",
                column: "ItemProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stock",
                newName: "StockQuantity");

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
                name: "FK_Stock_Cart_CartId",
                table: "Stock",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }
    }
}
