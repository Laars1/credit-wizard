using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DegreeController : Controller
    {
        private readonly IDegreeService _degreeService;
        private readonly IUserService _userService;
        private readonly ISemesterTimeSlotService _semesterTimeSlotService;
        private readonly IMapper _mapper;

        public DegreeController(IDegreeService degreeService, IUserService userService, ISemesterTimeSlotService semesterTimeSlotService, IMapper mapper)
        {
            _degreeService = degreeService;
            _userService = userService;
            _semesterTimeSlotService = semesterTimeSlotService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Degrees
        /// </summary>
        /// <returns>All Degress in from of a List DegreeDto</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DegreeDto>))]
        public async Task<IActionResult> GetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(_mapper.Map<List<DegreeDto>>(await _degreeService.GetAsync()));
        }

        /// <summary>
        /// Get specific Degree by its id
        /// </summary>
        /// <param name="id">Id of the searched Degree</param>
        /// <returns>A Degree in form of a DegreeDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DegreeDto))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(_mapper.Map<DegreeDto>(await _degreeService.GetByIdAsync(id)));
        }

        /// <summary>
        /// Get specific Degree by its id
        /// </summary>
        /// <param name="id">Id of the searched Degree</param>
        /// <returns>A Degree in form of a DegreeDto</returns>
        [HttpGet("user/current/degreemodules")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DegreeDto))]
        public async Task<IActionResult> GetByIdWithModulesAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetByIdAsync(Guid.Parse(userId));
            if (user == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });
            return Ok(_mapper.Map<DegreeDto>(await _degreeService.GetByIdWithModulesAsync(user.DegreeId)));
        }

        /// <summary>
        /// Get specific Degree by its id
        /// </summary>
        /// <param name="id">Id of the searched Degree</param>
        /// <returns>A Degree in form of a DegreeDto</returns>
        [HttpGet("user/current/degreemodules/timeslot/{timeslotId:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DegreeModulDto>))]
        public async Task<IActionResult> GetByIdWithModulesAsync(Guid timeslotId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetByIdAsync(Guid.Parse(userId));
            if (user == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = $"There is no matching entry for {nameof(credit_wizard_api.Models.User)} {userId}", StatusCode = 404 });

            var timeSlot = await _semesterTimeSlotService.GetByIdAsync(timeslotId);
            if (user == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = $"There is no matching entry for {nameof(SemesterTimeSlot)} {timeslotId}", StatusCode = 404 });

            return Ok(_mapper.Map<List<DegreeModulDto>>(await _degreeService.GetByIdWithModulesByTimeslotAsync(user.DegreeId, timeslotId)));
        }
    }
}
