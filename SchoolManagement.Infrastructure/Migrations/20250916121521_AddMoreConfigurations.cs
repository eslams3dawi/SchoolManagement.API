using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InstructorManager",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InstructorManager",
                table: "Departments",
                column: "InstructorManager",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InstructorManager",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InstructorManager",
                table: "Departments",
                column: "InstructorManager",
                principalTable: "Instructors",
                principalColumn: "InstructorId");
        }
    }
}
