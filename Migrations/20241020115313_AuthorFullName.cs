using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anca_Iulia_Ana_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class AuthorFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Author");
        }
    }
}
