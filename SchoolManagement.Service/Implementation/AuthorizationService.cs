using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Helpers.DTOs;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<string> AddRoleAsync(string roleName)
        {
            var identityRole = new IdentityRole
            {
                Name = roleName
            };
            var role = await _roleManager.CreateAsync(identityRole);

            if (role.Succeeded)
                return "Created";

            return "Something Wrong";
        }

        public async Task<string> AddRolesToUserAsync(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.AddToRolesAsync(user, roles);

            if (result.Succeeded)
                return "Assigned";
            else
                return "Something went wrong";
        }

        public async Task<string> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return "Not Found";

            var usersUseRole = await _userManager.GetUsersInRoleAsync(role.Name);
            if (usersUseRole.Count() > 0)
                return "Users Use This Role";

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return "Deleted";

            return "Something Went Wrong";
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            return role;
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.AsNoTracking().ToListAsync();
            return roles;
        }

        public async Task<bool> IsRoleNameExists(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            return roleExists;
        }

        public async Task<bool> IsUserIdExists(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user != null ? true : false;
        }

        public async Task<string> UpdateRoleAsync(UpdateRoleCommand request)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.Id);
            if (role == null)
                return "Not Found";

            role.Name = request.NewName;

            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded == true ? "Updated" : "Something Went Wrong";
        }
    }
}
