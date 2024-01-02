using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using credit_wizard_api.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace credit_wizard_api.Services
{
    /// <summary>
    /// Business logic for authentication, method comments are placed in its interface
    /// </summary>
    public class AuthenticationService : IAutenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;

        public AuthenticationService(IOptions<JwtSettings> options, UserManager<User> userManager)
        {
            _jwtSettings = options.Value;
            _userManager = userManager;
        }

        public JwtSecurityToken GenerateToken(Guid userId, List<string> userRoles)
        {
            // Prepare users claims, which will be stored into the token
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.JwtSecret));

            // Generate JWT-Token
            return new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                expires: DateTime.Now.AddDays(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result =  await _userManager.CheckPasswordAsync(user, password);
            return result;
        }
    }
}
