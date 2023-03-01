using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addrelationblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryCatergoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CatergoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryCatergoryId",
                table: "Blogs",
                column: "CategoryCatergoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Catergories_CategoryCatergoryId",
                table: "Blogs",
                column: "CategoryCatergoryId",
                principalTable: "Catergories",
                principalColumn: "CatergoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Catergories_CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CategoryCatergoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CatergoryId",
                table: "Blogs");
        }
    }
}
