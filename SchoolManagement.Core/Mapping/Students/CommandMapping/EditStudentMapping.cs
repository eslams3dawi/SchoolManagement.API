using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
             .ForMember(dest => dest.FirstNameEn, opts => opts.MapFrom(src => src.FirstNameEn))
             .ForMember(dest => dest.FirstNameAr, opts => opts.MapFrom(src => src.FirstNameAr))
             .ForMember(dest => dest.LastNameEn, opts => opts.MapFrom(src => src.LastNameEn))
             .ForMember(dest => dest.LastNameAr, opts => opts.MapFrom(src => src.LastNameAr))
             .ForMember(dest => dest.AddressEn, opts => opts.MapFrom(src => src.AddressEn))
             .ForMember(dest => dest.AddressAr, opts => opts.MapFrom(src => src.AddressAr));
        }
    }
}
