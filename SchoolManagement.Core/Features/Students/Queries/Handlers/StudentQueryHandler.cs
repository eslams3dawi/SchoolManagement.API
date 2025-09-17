using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Core.Features.Students.Queries.Response;
using SchoolManagement.Core.Resources;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                  IRequestHandler<GetStudentListQuery, Response<IEnumerable<GetStudentListResponse>>>,
                                  IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>,
                                  IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentQueryHandler(IStudentService studentService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<IEnumerable<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<IEnumerable<GetStudentListResponse>>(studentList);

            var result = Success(studentListMapper);
            result.Meta = new
            {
                Count = studentListMapper.Count(),
            };
            return result;
        }
        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetStudentByIdResponse>();

            var studentMapper = _mapper.Map<GetStudentByIdResponse>(student);

            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var filter = _studentService.FilterStudentsPaginatedQueryable(request.OrderBy, request.Search);
            //First Way:
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudentId,e.Localize(e.FirstNameAr, e.FirstNameEn), e.Localize(e.LastNameAr, e.LastNameEn), e.Localize(e.AddressAr, e.AddressEn), e.Phone, e.Localize(e.Department.NameAr, e.Department.NameEn));
            //var paginatedList = await filter.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            //Second Way:
            //var paginatedList = await filter
            //    .Select(x => new GetStudentPaginatedListResponse()
            //    { StudentId = x.StudentId, FirstName = x.Localize(x.FirstNameAr, x.FirstNameEn), LastName = x.Localize(x.LastNameAr, x.LastNameEn), Address = x.Localize(x.AddressAr, x.AddressEn), Phone = x.Phone, DepartmentName = x.Localize(x.Department.NameAr, x.Department.NameEn) })
            //                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            //Third Way:
            var paginatedList = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(filter)
                                .ToPaginatedListAsync(request.PageNumber, request.PageSize);


            paginatedList.Meta = new
            {
                Count = filter.Count(),
            };
            return paginatedList;
        }
    }
}
