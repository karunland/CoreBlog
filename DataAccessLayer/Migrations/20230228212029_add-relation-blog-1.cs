using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addrelationblog1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Catergories_CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CategoryCatergoryId",
                table: "Blogs",
                newName: "RCategoryCatergoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryCatergoryId",
                table: "Blogs",
                newName: "IX_Blogs_RCategoryCatergoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Catergories_RCategoryCatergoryId",
                table: "Blogs",
                column: "RCategoryCatergoryId",
                principalTable: "Catergories",
                principalColumn: "CatergoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Catergories_RCategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "RCategoryCatergoryId",
                table: "Blogs",
                newName: "CategoryCatergoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_RCategoryCatergoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryCatergoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Catergories_CategoryCatergoryId",
                table: "Blogs",
                column: "CategoryCatergoryId",
                principalTable: "Catergories",
                principalColumn: "CatergoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
