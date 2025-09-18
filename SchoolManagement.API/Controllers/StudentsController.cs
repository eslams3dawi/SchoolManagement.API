using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Data.AppMetaData;

namespace SchoolManagement.Controllers
{
    [ApiController]
    public class StudentsController : AppController
    {
        public StudentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudents()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> GetStudentsPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return NewResult(response);
        }
        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return NewResult(response);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
