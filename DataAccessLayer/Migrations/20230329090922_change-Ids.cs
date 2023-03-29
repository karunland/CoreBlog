using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changeIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterId",
                table: "Writers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MailId",
                table: "NewsLetters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Catergories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Blogs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AboutId",
                table: "Abouts",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Writers",
                newName: "WriterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NewsLetters",
                newName: "MailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contacts",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Catergories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blogs",
                newName: "BlogId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Abouts",
                newName: "AboutId");
        }
    }
}
