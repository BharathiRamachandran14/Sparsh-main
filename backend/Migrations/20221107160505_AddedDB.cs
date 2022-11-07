using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sparsh.Migrations
{
    public partial class AddedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    PricePerProduct = table.Column<double>(type: "double precision", nullable: false),
                    ProductImageUrl = table.Column<string>(type: "text", nullable: true),
                    ProductDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Storehouse",
                columns: table => new
                {
                    StorehouseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storehouse", x => x.StorehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    CartTotal = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_Wishlist_Product_ItemProductId",
                        column: x => x.ItemProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PurchaserUserId = table.Column<int>(type: "integer", nullable: true),
                    TotalValue = table.Column<double>(type: "double precision", nullable: false),
                    TransactionStatus = table.Column<int>(type: "integer", nullable: false),
                    StorehouseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Storehouse_StorehouseId",
                        column: x => x.StorehouseId,
                        principalTable: "Storehouse",
                        principalColumn: "StorehouseId");
                    table.ForeignKey(
                        name: "FK_Transaction_Users_PurchaserUserId",
                        column: x => x.PurchaserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemProductId = table.Column<int>(type: "integer", nullable: true),
                    StockQuantity = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    StorehouseId = table.Column<int>(type: "integer", nullable: true),
                    TransactionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stock_Product_ItemProductId",
                        column: x => x.ItemProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Stock_Storehouse_StorehouseId",
                        column: x => x.StorehouseId,
                        principalTable: "Storehouse",
                        principalColumn: "StorehouseId");
                    table.ForeignKey(
                        name: "FK_Stock_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ItemProductId",
                table: "Stock",
                column: "ItemProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StorehouseId",
                table: "Stock",
                column: "StorehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_TransactionId",
                table: "Stock",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PurchaserUserId",
                table: "Transaction",
                column: "PurchaserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_StorehouseId",
                table: "Transaction",
                column: "StorehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ItemProductId",
                table: "Wishlist",
                column: "ItemProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Storehouse");
        }
    }
}
