using AutoMapper;

namespace SchoolManagement.Core.Mapping.Authorization
{
    public partial class AuthorizationMapping : Profile
    {
        public AuthorizationMapping()
        {
            GetRolesMapping();
            GetRoleByIdMapping();
        }
    }
}
