using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Responses;

namespace SchoolManagement.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResponse>>
    {
        public GetRoleByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
