using AutoMapper;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            GetUsersPaginationMapping();
            GetUserByIdMapping();
            UpdateUserMapping();
        }
    }
}
