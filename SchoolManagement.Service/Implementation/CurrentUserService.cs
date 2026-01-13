using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Service.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _accessor;

        public CurrentUserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _accessor = accessor;
        }
        public async Task<ApplicationUser> GetCurrentUser()
        {
            var userId = GetCurrentUserId();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UnauthorizedAccessException();

            return user;
        }

        public string GetCurrentUserId()
        {
            var userId = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == nameof(UserClaims.Id));
            return userId == null ? throw new UnauthorizedAccessException() : userId.Value;
        }

        public async Task<List<string>> GetCurrentUserRoles(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
    }
}
