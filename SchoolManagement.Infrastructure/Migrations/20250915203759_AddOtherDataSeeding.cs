using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DepartmentSubjects",
                columns: new[] { "DepartmentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Address", "AddressAr", "Degree", "DegreeAr", "DepartmentId", "Email", "FirstName", "FirstNameAr", "LastName", "LastNameAr", "Phone", "Salary", "SupervisorId" },
                values: new object[,]
                {
                    { 1, "Cairo", null, "Professor", null, 1, "ahmed.ali@school.com", "Ahmed", null, "Ali", null, "0100000001", 60000m, null },
                    { 2, "Giza", null, "Associate Professor", null, 2, "mona.hassan@school.com", "Mona", null, "Hassan", null, "0100000002", 55000m, null },
                    { 3, "Alexandria", null, "Assistant Professor", null, 3, "khaled.ibrahim@school.com", "Khaled", null, "Ibrahim", null, "0100000003", 50000m, null },
                    { 4, "Cairo", null, "Lecturer", null, 1, "layla.mostafa@school.com", "Layla", null, "Mostafa", null, "0100000004", 48000m, null },
                    { 5, "Giza", null, "Lecturer", null, 2, "omar.fathy@school.com", "Omar", null, "Fathy", null, "0100000005", 47000m, null },
                    { 6, "Alexandria", null, "Assistant Lecturer", null, 3, "heba.adel@school.com", "Heba", null, "Adel", null, "0100000006", 46000m, null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AddressAr", "AddressEn", "DepartmentId", "FirstNameAr", "FirstNameEn", "LastNameAr", "LastNameEn", "Phone" },
                values: new object[,]
                {
                    { 1, null, "Cairo", 1, null, "Omar", null, "Mahmoud", "0101111111" },
                    { 2, null, "Giza", 2, null, "Sara", null, "Youssef", "0102222222" },
                    { 3, null, "Alexandria", 3, null, "Nour", null, "Adel", "0103333333" },
                    { 4, null, "Cairo", 1, null, "Ali", null, "Mostafa", "0104444444" },
                    { 5, null, "Giza", 2, null, "Mariam", null, "Hassan", "0105555555" },
                    { 6, null, "Alexandria", 3, null, "Youssef", null, "Ibrahim", "0106666666" },
                    { 7, null, "Cairo", 1, null, "Dina", null, "Khaled", "0107777777" },
                    { 8, null, "Giza", 2, null, "Hassan", null, "Omar", "0108888888" },
                    { 9, null, "Alexandria", 3, null, "Aya", null, "Mohamed", "0109999999" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DepartmentSubjects",
                keyColumns: new[] { "DepartmentId", "SubjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DepartmentSubjects",
                keyColumns: new[] { "DepartmentId", "SubjectId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DepartmentSubjects",
                keyColumns: new[] { "DepartmentId", "SubjectId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DepartmentSubjects",
                keyColumns: new[] { "DepartmentId", "SubjectId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9);
        }
    }
}
