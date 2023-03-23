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
        /// <returns></returns>
        public JwtSecurityToken GenerateToken(Guid userId, List<string> userRoles);
    }
}
