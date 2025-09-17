using SchoolManagement.Core.Wrappers;

namespace SchoolManagement.Core.Features.Department.Queries.Response
{
    public class GetDepartmentByIdResponse
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string? InstructorManagerName { get; set; }
        public PaginatedResult<StudentResponse>? StudentsList { get; set; }
        public List<SubjectResponse>? SubjectsList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }
    }

    public class StudentResponse
    {
        public StudentResponse(int studentId, string fullName)
        {
            StudentId = studentId;
            FullName = fullName;
        }

        public int StudentId { get; set; }
        public string FullName { get; set; }
    }
    public class SubjectResponse
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponse
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; }
    }
}
