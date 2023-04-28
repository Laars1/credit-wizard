using credit_wizard_api.Models;
using System.IdentityModel.Tokens.Jwt;

namespace credit_wizard_api.Services.Interfaces
{
    public interface IAutenticationService
    {
        /// <summary>
        /// Genearte JWT Token for login
        /// With the stord params in the key the user can be recognized by the identity with its id
        /// </summary>
        /// <param name="userId">id of the logged in user, this value is stored in the stoken</param>
        /// <param name="userRoles">roles of the user, this value is stored in the stoken</param>
        /// <returns>The generated Jwt token</returns>
        public JwtSecurityToken GenerateToken(Guid userId, List<string> userRoles);

        /// <summary>
        /// Check if password is matched with the data record
        /// </summary>
        /// <param name="user">object of the user which wants to log in</param>
        /// <param name="password">passed password</param>
        /// <returns>true if password machtes</returns>
        public Task<bool> CheckPasswordAsync(User user, string password);
    }
}
