namespace SchoolManagement.Core.Features.Students.Queries.Response
{
    public class GetStudentListResponse
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DepartmentName { get; set; }
    }
}
