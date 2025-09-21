using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Data.Helpers;

namespace SchoolManagement.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
