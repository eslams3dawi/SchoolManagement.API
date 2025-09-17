using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Department.Queries.Response;

namespace SchoolManagement.Core.Features.Department.Queries.Model
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int DepartmentId { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }
}
