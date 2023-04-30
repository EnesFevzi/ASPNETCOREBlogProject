using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_about_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CancerAboutHead5",
                table: "Abouts",
                newName: "AboutHead5");

            migrationBuilder.RenameColumn(
                name: "CancerAboutHead4",
                table: "Abouts",
                newName: "AboutHead4");

            migrationBuilder.RenameColumn(
                name: "CancerAboutHead3",
                table: "Abouts",
                newName: "AboutHead3");

            migrationBuilder.RenameColumn(
                name: "CancerAboutHead2",
                table: "Abouts",
                newName: "AboutHead2");

            migrationBuilder.RenameColumn(
                name: "CancerAboutHead1",
                table: "Abouts",
                newName: "AboutHead1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutHead5",
                table: "Abouts",
                newName: "CancerAboutHead5");

            migrationBuilder.RenameColumn(
                name: "AboutHead4",
                table: "Abouts",
                newName: "CancerAboutHead4");

            migrationBuilder.RenameColumn(
                name: "AboutHead3",
                table: "Abouts",
                newName: "CancerAboutHead3");

            migrationBuilder.RenameColumn(
                name: "AboutHead2",
                table: "Abouts",
                newName: "CancerAboutHead2");

            migrationBuilder.RenameColumn(
                name: "AboutHead1",
                table: "Abouts",
                newName: "CancerAboutHead1");
        }
    }
}
