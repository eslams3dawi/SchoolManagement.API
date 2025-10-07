using SchoolManagement.Data.Helpers;
using SchoolManagement.Data.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolManagement.Service.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResponse> GetJwtToken(ApplicationUser user);
        public Task<JwtAuthResponse> GetRefreshToken(JwtSecurityToken jwtToken, DateTime? userRefreshTokenExpiryDate, ApplicationUser user, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<(string, DateTime?)> ValidateOnDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        public Task<string> ConfirmEmail(string userId, string code);
        public Task<string> SendResetPasswordAsync(string email);
        public Task<string> ConfirmResetPasswordAsync(string code, string email);
        public Task<string> ResetPasswordAsync(string email, string newPassword);
        public Task<bool> IsEmailExists(string email);
    }
}
