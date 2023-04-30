using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_about_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CancerboutImage4",
                table: "CancerAbouts",
                newName: "CancerAboutImage4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CancerAboutImage4",
                table: "CancerAbouts",
                newName: "CancerboutImage4");
        }
    }
}
