using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.Features.Authentication.Queries.Models;
using SchoolManagement.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagement.API.Controllers
{
    ////Admin or Instructor
    //[Authorize(Roles = "Admin, Instructor")] 

    ////Admin And Instructor at the same time
    //[Authorize(Roles = "Admin")]
    //[Authorize(Roles = "Instructor")]
    [ApiController]
    public class AuthenticationController : AppController
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Router.AuthenticationRouting.SignIn)]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Generate new access token using valid refresh token", OperationId = "RefreshToken")]
        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Validate on access token, if is expired or not", OperationId = "ValidateToken")]
        [HttpGet(Router.AuthenticationRouting.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }
    }
}
