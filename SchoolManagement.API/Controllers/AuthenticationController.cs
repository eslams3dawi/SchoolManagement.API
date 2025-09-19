using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Authentication.Commands.Models;
using SchoolManagement.Data.AppMetaData;

namespace SchoolManagement.API.Controllers
{
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
    }
}
