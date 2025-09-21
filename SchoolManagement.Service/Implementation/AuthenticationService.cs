using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Data.Identity;
using SchoolManagement.Infrastructure.Interfaces;
using SchoolManagement.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagement.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository, UserManager<ApplicationUser> userManager)
        {
            _jwtSettings = jwtSettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
        }
        public async Task<JwtAuthResponse> GetJwtToken(ApplicationUser user)
        {
            var (JwtToken, AccessToken) = GenerateJwtToken(user);
            var RefreshToken = GetRefreshToken(user.UserName);

            //Store refresh token in database
            var userRefreshToken = new UserRefreshToken
            {
                UserId = user.Id,
                JwtId = JwtToken.Id,
                RefreshToken = RefreshToken.RefershTokenString,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                Token = AccessToken,
                IsUsed = true,
                IsRevoked = false,
            };
            await _refreshTokenRepository.AddAsync(userRefreshToken);


            var jwtResponse = new JwtAuthResponse
            {
                AcessToken = AccessToken,
                RefreshToken = RefreshToken
            };

            return jwtResponse;
        }

        private (JwtSecurityToken, string) GenerateJwtToken(ApplicationUser user)
        {
            var Claims = GetClaims(user);
            var Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpireDate);
            var JwtToken = new JwtSecurityToken
            (
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims: Claims,
                expires: Expires,
                signingCredentials: GetSigningCredentials()
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(JwtToken);

            return (JwtToken, accessToken);
        }
        private List<Claim> GetClaims(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(nameof(UserClaims.Id), user.Id),
                new Claim(nameof(UserClaims.UserName), user.UserName),
                new Claim(nameof(UserClaims.Email), user.Email),
                new Claim(nameof(UserClaims.PhoneNumber), user.PhoneNumber)
            };

            return Claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var securityKeyString = _jwtSettings.SecretKey;
            var securityKeyByte = Encoding.ASCII.GetBytes(securityKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(securityKeyByte);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            return signingCredentials;
        }

        private RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                UserName = userName,
                ExpireAt = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                RefershTokenString = GenerateRefreshToken()
            };

            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            // 1) Allocate array of 32 bytes (256-bit)
            var randomNumber = new byte[32];
            // 2) Create a secure random number generator (cryptographic)
            var randomNumberGenerator = RandomNumberGenerator.Create();
            // 3) Fill the array with random bytes
            randomNumberGenerator.GetBytes(randomNumber);
            // 4) Convert the random byte array into Base64 string (easy to store & transmit)
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<JwtAuthResponse> GetRefreshToken(JwtSecurityToken jwtToken, DateTime? userRefreshTokenExpiryDate, ApplicationUser user, string refreshToken)
        {
            var (JwtToken, newAccessToken) = GenerateJwtToken(user);

            var refreshTokenResult = new RefreshToken
            {
                UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaims.UserName)).Value,
                RefershTokenString = refreshToken,
                ExpireAt = (DateTime)userRefreshTokenExpiryDate
            };
            return new JwtAuthResponse
            {
                AcessToken = newAccessToken,
                RefreshToken = refreshTokenResult
            };
        }


        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(accessToken);
            return decodedToken;
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKeyString = _jwtSettings.SecretKey;
            var securityKeyByte = Encoding.ASCII.GetBytes(securityKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(securityKeyByte);
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = securityKey,
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime
            };

            try
            {
                var validator = tokenHandler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);
                if (validator == null)
                    return "Invalid Token";

                return "Valid Token";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> ValidateOnDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || jwtToken.Header.Alg != SecurityAlgorithms.HmacSha256Signature)
                return ("Invalid Algorithm", null);

            if (jwtToken.ValidTo > DateTime.UtcNow)
                return ("Token Is Not Expired", null);

            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaims.Id))?.Value;
            if (userId == null)
                return ("Invalid Token Claims", null);

            var userRefreshToken = _refreshTokenRepository
                                    .GetTableNoTracking()
                                    .FirstOrDefault(x => x.RefreshToken == refreshToken &&
                                                    x.Token == accessToken &&
                                                    x.UserId == userId);

            if (userRefreshToken == null)
                return ("Refresh Token Is Not Found", null);

            if (userRefreshToken.ExpirationDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("Refresh Token Is Expired", null);
            }

            return (userId, userRefreshToken.ExpirationDate);
        }
    }
}
