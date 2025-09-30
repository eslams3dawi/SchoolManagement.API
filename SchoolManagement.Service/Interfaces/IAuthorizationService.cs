using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Helpers.DTOs;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Service.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);

        public Task<bool> IsRoleNameExists(string roleName);
        public Task<bool> IsUserIdExists(string userId);

        public Task<string> AddRoleAsync(string roleName);
        public Task<string> UpdateRoleAsync(UpdateRoleRequest request);
        public Task<List<IdentityRole>> GetRolesAsync();
        public Task<IdentityRole> GetRoleByIdAsync(string roleId);
        public Task<string> DeleteRoleAsync(string roleId);

        public Task<ManageUserRolesResponse> GetManageUserRolesData(ApplicationUser user);
        public Task<ManageUserClaimsResponse> ManageUserClaimsData(ApplicationUser user);
    }
}
