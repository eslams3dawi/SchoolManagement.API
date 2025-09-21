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
    }
}
