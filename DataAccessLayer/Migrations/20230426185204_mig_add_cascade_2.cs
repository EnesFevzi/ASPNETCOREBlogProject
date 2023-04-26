using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_cascade_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogScore",
                table: "Comments",
                newName: "BlogScore2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogScore2",
                table: "Comments",
                newName: "BlogScore");
        }
    }
}
