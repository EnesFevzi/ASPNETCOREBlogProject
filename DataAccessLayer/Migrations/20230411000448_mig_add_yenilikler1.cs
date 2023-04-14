using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_yenilikler1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_WriterID",
                table: "Videos",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_News_WriterID",
                table: "News",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_WriterID",
                table: "News",
                column: "WriterID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_WriterID",
                table: "Videos",
                column: "WriterID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_WriterID",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_WriterID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_WriterID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_News_WriterID",
                table: "News");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "News");

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
    }
}
