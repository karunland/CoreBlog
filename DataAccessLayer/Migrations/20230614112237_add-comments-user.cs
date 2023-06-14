using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcommentsuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterPasswordAgain",
                table: "Writers");

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isUser",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "isUser",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "WriterPasswordAgain",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
