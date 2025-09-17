using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Queries.Response;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<IEnumerable<GetStudentListResponse>>>
    {
    }
}
