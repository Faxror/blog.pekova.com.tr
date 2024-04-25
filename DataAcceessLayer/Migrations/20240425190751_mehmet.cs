using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcceessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mehmet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Authors",
                newName: "ShortAbout");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "ShortAbout",
                table: "Authors",
                newName: "Username");
        }
    }
}
