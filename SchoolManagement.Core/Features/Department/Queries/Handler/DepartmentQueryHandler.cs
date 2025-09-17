using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Department.Queries.Model;
using SchoolManagement.Core.Features.Department.Queries.Response;
using SchoolManagement.Core.Resources;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Interfaces;
using System.Linq.Expressions;

namespace SchoolManagement.Core.Features.Department.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
                                          IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>

    {
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public DepartmentQueryHandler(IDepartmentService departmentService, IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(request.DepartmentId);
            if (department == null)
                return NotFound<GetDepartmentByIdResponse>();

            var departmentMapper = _mapper.Map<GetDepartmentByIdResponse>(department);

            Expression<Func<Student, StudentResponse>> expression =
                                e => new StudentResponse(e.StudentId, e.Localize(e.FirstNameAr, e.FirstNameEn) + " " + e.Localize(e.LastNameAr, e.LastNameEn));

            var studentsQueryable = _studentService.GetStudentsByDepartmentQueryable(request.DepartmentId);
            var paginatedList = await studentsQueryable
                    .Select(expression)
                    .ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);

            departmentMapper.StudentsList = paginatedList;
            return Success(departmentMapper);
        }
    }
}
