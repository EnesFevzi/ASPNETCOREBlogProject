using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
