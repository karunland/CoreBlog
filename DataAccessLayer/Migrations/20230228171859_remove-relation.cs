using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class removerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Catergories_CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Blogs_BlogId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_BlogId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CatergoryId",
                table: "Blogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatergoryId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatergoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_BlogId",
                table: "Contact",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryCatergoryId",
                table: "Blogs",
                column: "CategoryCatergoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Catergories_CategoryCatergoryId",
                table: "Blogs",
                column: "CategoryCatergoryId",
                principalTable: "Catergories",
                principalColumn: "CatergoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Blogs_BlogId",
                table: "Contact",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }
    }
}
