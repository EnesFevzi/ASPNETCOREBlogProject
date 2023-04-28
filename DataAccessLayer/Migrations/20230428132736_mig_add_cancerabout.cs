using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_cancerabout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancerAbouts",
                columns: table => new
                {
                    CancerAboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CancerAboutHead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutHead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutHead3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutHead4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutHead5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutDetails1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutDetails2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutDetails3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutDetails4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerAboutDetails5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutMapLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancerAbouts", x => x.CancerAboutID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancerAbouts");
        }
    }
}
