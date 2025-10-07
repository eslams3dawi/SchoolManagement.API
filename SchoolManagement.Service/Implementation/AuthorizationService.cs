using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Data.Helpers.DTOs;
using SchoolManagement.Data.Identity;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Service.Interfaces;
using System.Security.Claims;

namespace SchoolManagement.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
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

        public async Task<string> UpdateUserRoles(UpdateUserRolesRequest request)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                var userRoles = await _userManager.GetRolesAsync(user);


                var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                if (!removeResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return "Something Went Wrong While Removing Old User Roles";
                }

                var selectedRoles = request.Roles.Where(x => x.HasRole == true).Select(x => x.Name);
                var assignResult = await _userManager.AddToRolesAsync(user, selectedRoles);

                if (!assignResult.Succeeded)
                {
                    return "Something Went Wrong While Adding User Roles";
                }
                await transaction.CommitAsync();
                return "Assigned";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return "Something Went Wrong In Database While Updating User Roles";
            }
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

        public async Task<ManageUserRolesResponse> GetManageUserRolesData(ApplicationUser user)
        {
            var dbRoles = await _roleManager.Roles.ToListAsync();
            var roles = new List<Roles>();

            foreach (var dbRole in dbRoles)
            {
                var roleResponse = new Roles() { Id = dbRole.Id, Name = dbRole.Name };
                if (await _userManager.IsInRoleAsync(user, dbRole.Name))
                    roleResponse.HasRole = true;

                roles.Add(roleResponse);
            }

            var response = new ManageUserRolesResponse()
            {
                UserId = user.Id,
                Roles = roles
            };
            return response;
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

        public async Task<string> UpdateRoleAsync(UpdateRoleRequest request)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == request.Id);
            if (role == null)
                return "Not Found";

            role.Name = request.NewName;

            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded == true ? "Updated" : "Something Went Wrong";
        }

        public async Task<ManageUserClaimsResponse> ManageUserClaimsData(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var dbClaims = new ClaimStore().Claims;
            var claims = new List<Claims>();

            foreach (var dbClaim in dbClaims)
            {
                var claim = new Claims { Type = dbClaim.Type };
                if (userClaims.Any(x => x.Type == dbClaim.Type))
                {
                    claim.Value = true;
                }
                claims.Add(claim);
            }

            var response = new ManageUserClaimsResponse
            {
                UserId = user.Id,
                Claims = claims
            };

            return response;
        }

        public async Task<string> UpdateUserClaims(UpdateUserClaimsRequest request)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                var userClaims = await _userManager.GetClaimsAsync(user);

                var removingResult = await _userManager.RemoveClaimsAsync(user, userClaims);
                if (!removingResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return "Something Went Wrong While Removing Old User Claims";
                }

                var selectedClaims = request.Claims
                                            .Where(x => x.Value == true)
                                            .Select(x => new Claim(type: x.Type, value: x.Value.ToString()))
                                            .ToList();

                var assignResult = await _userManager.AddClaimsAsync(user, selectedClaims);
                if (!assignResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return "Something Went Wrong While Adding User Claims";
                }

                await transaction.CommitAsync();
                return "Assigned";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return "Something Went Wrong In Database While Updating User Claims";
            }
        }
    }
}
