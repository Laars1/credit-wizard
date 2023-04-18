using System.Security.Claims;
using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace credit_wizard_api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Get all required data from logged in user
    /// </summary>
    /// <returns>User object with its data</returns>
    [HttpGet("current")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    public async Task<IActionResult> GetCurrentUserAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(_mapper.Map<UserDto>(await _userService.GetByIdAsync(Guid.Parse(userId))));
    }
    
    [HttpGet("current/degreeprogress")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    public async Task<IActionResult> GetCurrentDegreeProgress()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _userService.GetCurrentDegreeProgress(Guid.Parse(userId));
        return Ok(data);
    }
}