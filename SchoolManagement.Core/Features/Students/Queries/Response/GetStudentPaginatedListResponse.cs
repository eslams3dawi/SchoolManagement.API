namespace SchoolManagement.Core.Features.Students.Queries.Response
{
    public class GetStudentPaginatedListResponse
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DepartmentName { get; set; }

        public GetStudentPaginatedListResponse(int studentId, string firstName, string lastName, string address, string phone, string departmentName)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            DepartmentName = departmentName;
        }
    }
}
