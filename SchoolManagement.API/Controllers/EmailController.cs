using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Email.Commands.Models;
using SchoolManagement.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    public class EmailController : AppController
    {
        public EmailController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "Admin, Instructor")]
        [SwaggerOperation(Summary = "This endpoint allows Admins or Instructors to send an email to a specified recipient." +
                                     "By providing recipient's email, subject and message body"
                          , OperationId = "SendEmail")]
        [HttpPost(Router.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
    }
}
