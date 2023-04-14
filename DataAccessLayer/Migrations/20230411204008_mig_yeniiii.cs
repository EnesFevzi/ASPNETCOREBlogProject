using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_yeniiii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoImage",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "VideoThumbnailImage",
                table: "Videos",
                newName: "VideoURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoURL",
                table: "Videos",
                newName: "VideoThumbnailImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Videos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoImage",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
