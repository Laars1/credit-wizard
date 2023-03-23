using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using credit_wizard_api.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace credit_wizard_api.Services
{
    public class AuthenticationService : IAutenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public JwtSecurityToken GenerateToken(Guid userId, List<string> userRoles)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.JwtSecret));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                expires: DateTime.Now.AddSeconds(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
