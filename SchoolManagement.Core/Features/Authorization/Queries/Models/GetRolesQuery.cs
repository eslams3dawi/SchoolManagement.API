using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Responses;

namespace SchoolManagement.Core.Features.Authorization.Queries.Models
{
    public class GetRolesQuery : IRequest<Response<List<GetRolesResponse>>>
    {
    }
}
