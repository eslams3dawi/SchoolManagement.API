using SchoolManagement.Core.Features.User.Queries.Responses;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUsersPaginationMapping()
        {
            CreateMap<ApplicationUser, GetUsersPaginationResponse>();
        }
    }
}
