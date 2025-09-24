using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Helpers.DTOs;

namespace SchoolManagement.Service.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<string> AddRolesToUserAsync(string userId, List<string> roles);
        public Task<bool> IsRoleNameExists(string roleName);
        public Task<bool> IsUserIdExists(string userId);

        public Task<string> AddRoleAsync(string roleName);
        public Task<string> UpdateRoleAsync(UpdateRoleCommand request);
        public Task<List<IdentityRole>> GetRolesAsync();
        public Task<IdentityRole> GetRoleByIdAsync(string roleId);
        public Task<string> DeleteRoleAsync(string roleId);
    }
}
