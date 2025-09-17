using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameInsSubTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorId",
                table: "InstructorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectId",
                table: "InstructorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSubject",
                table: "InstructorSubject");

            migrationBuilder.RenameTable(
                name: "InstructorSubject",
                newName: "InstructorSubjects");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSubject_SubjectId",
                table: "InstructorSubjects",
                newName: "IX_InstructorSubjects_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSubjects",
                table: "InstructorSubjects",
                columns: new[] { "InstructorId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubjects_Instructors_InstructorId",
                table: "InstructorSubjects",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubjects_Subjects_SubjectId",
                table: "InstructorSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubjects_Instructors_InstructorId",
                table: "InstructorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubjects_Subjects_SubjectId",
                table: "InstructorSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSubjects",
                table: "InstructorSubjects");

            migrationBuilder.RenameTable(
                name: "InstructorSubjects",
                newName: "InstructorSubject");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSubjects_SubjectId",
                table: "InstructorSubject",
                newName: "IX_InstructorSubject_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSubject",
                table: "InstructorSubject",
                columns: new[] { "InstructorId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Instructors_InstructorId",
                table: "InstructorSubject",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectId",
                table: "InstructorSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
