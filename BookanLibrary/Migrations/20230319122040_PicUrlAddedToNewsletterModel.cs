using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookanLibrary.Migrations
{
    /// <inheritdoc />
    public partial class PicUrlAddedToNewsletterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicUrl",
                table: "Newsletters",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicUrl",
                table: "Newsletters");
        }
    }
}
