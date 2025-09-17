using MediatR;
using SchoolManagement.Core.Features.Students.Queries.Response;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Data.Helpers;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public GetStudentPaginatedListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetStudentPaginatedListQuery()
        {

        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
