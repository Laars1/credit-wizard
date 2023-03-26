using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Models;
using credit_wizard_api.Services;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SemesterPlannerController : Controller
    {
        private readonly ISemesterPlannerService _semesterPlannerService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public SemesterPlannerController(ISemesterPlannerService semesterPlannerService, UserManager<User> userManager, IMapper mapper)
        {
            _semesterPlannerService = semesterPlannerService;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <summary>
        /// Get all planned semester for logged in user
        /// </summary>
        /// <returns>List ofSemesterPlannerDto with the provided data</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SemesterPlannerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAsync(Guid.Parse(userId));

            return Ok(_mapper.Map<List<SemesterPlannerDto>>(data));
        }


        /// <summary>
        /// Get planned semester for logged in user by semesterid
        /// </summary>
        /// <param name="semesterId">semesterid from which the data should be loaded</param>
        /// <returns>SemesterPlannerDto with the provided data</returns>
        [HttpGet("{semesterId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SemesterPlannerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserAndSemesterIdAsync(Guid semesterId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAndSemesterIdAsync(Guid.Parse(userId), semesterId);

            if (data == null) return NotFound("There is no matching entry");

            return Ok(_mapper.Map<SemesterPlannerDto>(data));
        }

        /// <summary>
        /// Get planned semester for logged in user by semesternumber
        /// </summary>
        /// <param name="semesterNumber">Semesternumer from which the data should be loaded</param>
        /// <returns>SemesterPlannerDto with the provided data</returns>
        [HttpGet("{semesterNumber:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SemesterPlannerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserAndSemesterNumberAsync(int semesterNumber)
        {
            if (semesterNumber == 0 || semesterNumber > 100) return BadRequest("Die eingegebene Semester Nummer ist ungültig");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAndSemesterNumberAsync(Guid.Parse(userId), semesterNumber);

            if (data == null) return NotFound("There is no matching entry");

            return Ok(_mapper.Map<SemesterPlannerDto>(data));
        }
    }
}
