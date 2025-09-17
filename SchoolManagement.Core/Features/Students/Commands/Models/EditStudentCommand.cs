using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string AddressEn { get; set; }
        public string? FirstNameAr { get; set; }
        public string? LastNameAr { get; set; }
        public string? AddressAr { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
