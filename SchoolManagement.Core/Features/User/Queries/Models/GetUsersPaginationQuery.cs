using MediatR;
using SchoolManagement.Core.Features.User.Queries.Responses;
using SchoolManagement.Core.Wrappers;

namespace SchoolManagement.Core.Features.User.Queries.Models
{
    public class GetUsersPaginationQuery : IRequest<PaginatedResult<GetUsersPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
