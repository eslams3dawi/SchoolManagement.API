using SchoolManagement.Core.Features.Students.Queries.Response;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentPaginatedListMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Localize(src.FirstNameAr, src.FirstNameEn)))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Localize(src.LastNameAr, src.LastNameEn)))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Localize(src.AddressAr, src.AddressEn)))
           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.NameAr, src.Department.NameEn)));
        }
    }
}
