using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public DeleteStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
    }
}
