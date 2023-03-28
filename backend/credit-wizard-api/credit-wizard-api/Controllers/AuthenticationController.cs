using credit_wizard_api.Dtos;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {

        private readonly IUserService _userService;
        private readonly IAutenticationService _autenticationService;

        public AuthenticationController(IUserService userService, IAutenticationService autenticationService)
        {
            _userService = userService;
            _autenticationService = autenticationService;
        }

        /// <summary>
        /// Login user with its credentials
        /// </summary>
        /// <param name="model">Credentails of user</param>
        /// <returns>When valid token, otherwise an error</returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userService.GetByNameAsync(model.Username);

            if (user != null && await _autenticationService.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userService.GetRolesFromUserAsync(user.UserName);
                var token = _autenticationService.GenerateToken(user.Id, userRoles.ToList() ?? new List<string>());
                return Ok(new TokenDto()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}
