using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagement.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(nameof(UserClaims.UserName), user.UserName),
                new Claim(nameof(UserClaims.Email), user.Email),
                new Claim(nameof(UserClaims.PhoneNumber), user.PhoneNumber)
            };
            var Expires = DateTime.UtcNow.AddDays(1);

            var securityKeyString = _jwtSettings.SecretKey;
            var securityKeyByte = Encoding.ASCII.GetBytes(securityKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(securityKeyByte);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var JwtToken = new JwtSecurityToken
            (
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims: Claims,
                expires: Expires,
                signingCredentials: signingCredentials
            );
            var Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            return Token;
        }
    }
}
