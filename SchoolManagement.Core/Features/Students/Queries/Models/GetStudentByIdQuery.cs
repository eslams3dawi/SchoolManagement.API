using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Queries.Response;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentByIdResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; } //As request will take the Id from user
    }
}
