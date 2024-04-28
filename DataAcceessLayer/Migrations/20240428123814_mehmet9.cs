using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcceessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mehmet9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AuthorID",
                table: "AspNetUsers",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CategoryID",
                table: "AspNetUsers",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Authors_AuthorID",
                table: "AspNetUsers",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Categories_CategoryID",
                table: "AspNetUsers",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Authors_AuthorID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Categories_CategoryID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AuthorID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CategoryID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "AspNetUsers");
        }
    }
}
