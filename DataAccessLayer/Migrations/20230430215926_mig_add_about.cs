using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject1.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutImage2",
                table: "CancerAbouts",
                newName: "CancerboutImage4");

            migrationBuilder.RenameColumn(
                name: "AboutImage1",
                table: "CancerAbouts",
                newName: "CancerAboutImage5");

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutImage1",
                table: "CancerAbouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutImage2",
                table: "CancerAbouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutImage3",
                table: "CancerAbouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutMapLocation",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboutImage2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboutImage1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboutDetails2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboutDetails1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AboutDetails3",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutDetails4",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutDetails5",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImage3",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImage4",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImage5",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutHead1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutHead2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutHead3",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutHead4",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancerAboutHead5",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancerAboutImage1",
                table: "CancerAbouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutImage2",
                table: "CancerAbouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutImage3",
                table: "CancerAbouts");

            migrationBuilder.DropColumn(
                name: "AboutDetails3",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutDetails4",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutDetails5",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutImage3",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutImage4",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutImage5",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutHead1",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutHead2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutHead3",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutHead4",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CancerAboutHead5",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "CancerboutImage4",
                table: "CancerAbouts",
                newName: "AboutImage2");

            migrationBuilder.RenameColumn(
                name: "CancerAboutImage5",
                table: "CancerAbouts",
                newName: "AboutImage1");

            migrationBuilder.AlterColumn<string>(
                name: "AboutMapLocation",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutImage2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutImage1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutDetails2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutDetails1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
