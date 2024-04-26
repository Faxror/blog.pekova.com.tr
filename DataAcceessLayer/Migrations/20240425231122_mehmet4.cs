using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcceessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mehmet4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirimCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirimCode",
                table: "AspNetUsers");
        }
    }
}
