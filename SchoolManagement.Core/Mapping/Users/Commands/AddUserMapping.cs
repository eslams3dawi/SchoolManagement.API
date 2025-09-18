using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddUserCommand, ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
