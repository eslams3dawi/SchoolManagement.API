using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Department.Queries.Model;
using SchoolManagement.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    public class DepartmentsController : AppController
    {
        public DepartmentsController(IMediator mediator) : base(mediator) { }


        [Authorize("Admin, Instructor, Student")]
        [HttpGet(Router.DepartmentRouting.GetById)]
        [SwaggerOperation(Summary = "Return a paginated result of single department with assigned students, instructors and subjects", OperationId = "GetRoleById")]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }
    }
}
