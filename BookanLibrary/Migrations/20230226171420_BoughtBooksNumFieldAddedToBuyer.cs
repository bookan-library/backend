using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookanLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BoughtBooksNumFieldAddedToBuyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Books_bookId",
                table: "WishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Buyers_buyerId",
                table: "WishLists");

            migrationBuilder.RenameColumn(
                name: "buyerId",
                table: "WishLists",
                newName: "BuyerId");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "WishLists",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_buyerId",
                table: "WishLists",
                newName: "IX_WishLists_BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_bookId",
                table: "WishLists",
                newName: "IX_WishLists_BookId");

            migrationBuilder.AddColumn<int>(
                name: "BoughtBooksNum",
                table: "Buyers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Books_BookId",
                table: "WishLists",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Buyers_BuyerId",
                table: "WishLists",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Books_BookId",
                table: "WishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Buyers_BuyerId",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "BoughtBooksNum",
                table: "Buyers");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "WishLists",
                newName: "buyerId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "WishLists",
                newName: "bookId");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_BuyerId",
                table: "WishLists",
                newName: "IX_WishLists_buyerId");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_BookId",
                table: "WishLists",
                newName: "IX_WishLists_bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Books_bookId",
                table: "WishLists",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Buyers_buyerId",
                table: "WishLists",
                column: "buyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
