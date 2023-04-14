using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_yenilikler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterUserId",
                table: "Videos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WriterUserId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_WriterUserId",
                table: "Videos",
                column: "WriterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_WriterUserId",
                table: "News",
                column: "WriterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_WriterUserId",
                table: "News",
                column: "WriterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_WriterUserId",
                table: "Videos",
                column: "WriterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_WriterUserId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_WriterUserId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_WriterUserId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_News_WriterUserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WriterUserId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "WriterUserId",
                table: "News");
        }
    }
}
