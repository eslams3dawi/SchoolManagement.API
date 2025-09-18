using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, ApplicationUser>();
        }
    }
}
