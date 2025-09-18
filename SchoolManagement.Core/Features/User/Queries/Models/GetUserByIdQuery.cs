using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Queries.Responses;

namespace SchoolManagement.Core.Features.User.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
