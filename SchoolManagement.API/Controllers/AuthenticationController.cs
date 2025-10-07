using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.Features.Authentication.Queries.Models;
using SchoolManagement.Core.Features.User.Commands.Models;
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

        [SwaggerOperation(Summary = "SignIn by existing account without registration", OperationId = "SignIn")]
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

        [SwaggerOperation(Summary = "Confirm email of user account when registration", OperationId = "ConfirmEmail")]
        [HttpGet(Router.AuthenticationRouting.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Send code to user's email to use it to reset password, for unlogged user", OperationId = "SendResetPassword")]
        [HttpPost(Router.AuthenticationRouting.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Confirm on received user's code", OperationId = "ConfirmResetPassword")]
        [HttpGet(Router.AuthenticationRouting.ConfirmResetPassword)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ResetPasswordQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "This endpoint changes user's password by user's email and entering new password twice without entering old password", OperationId = "ResetPassword")]
        [HttpPost(Router.AuthenticationRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.AuthenticationRouting.ChangePassword)]
        [SwaggerOperation(Summary = "Changes the user's password by entering old and new password for logged in user", OperationId = "ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
    }
}
