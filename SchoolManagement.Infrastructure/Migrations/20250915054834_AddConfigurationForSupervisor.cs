using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurationForSupervisor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InstructorManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_DepartmentId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Instructor_SupervisorId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Instructor_InstructorId",
                table: "InstructorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructors",
                newName: "IX_Instructors_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_DepartmentId",
                table: "Instructors",
                newName: "IX_Instructors_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InstructorManager",
                table: "Departments",
                column: "InstructorManager",
                principalTable: "Instructors",
                principalColumn: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Instructors_SupervisorId",
                table: "Instructors",
                column: "SupervisorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorId",
                table: "InstructorSubject",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InstructorManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Instructors_SupervisorId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorId",
                table: "InstructorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_SupervisorId",
                table: "Instructor",
                newName: "IX_Instructor_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructor",
                newName: "IX_Instructor_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InstructorManager",
                table: "Departments",
                column: "InstructorManager",
                principalTable: "Instructor",
                principalColumn: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_DepartmentId",
                table: "Instructor",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Instructor_InstructorId",
                table: "InstructorSubject",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
