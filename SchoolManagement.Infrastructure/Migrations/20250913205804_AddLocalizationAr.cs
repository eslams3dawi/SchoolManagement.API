using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizationAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "SubjectNameEn");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "LastNameEn");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "FirstNameEn");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "AddressEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameAr",
                table: "Subjects",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstNameAr",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastNameAr",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressAr",
                table: "Students",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectNameAr",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AddressAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstNameAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstNameEn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SubjectNameEn",
                table: "Subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "LastNameEn",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "LastNameAr",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AddressEn",
                table: "Students",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Departments",
                newName: "Name");
        }
    }
}
