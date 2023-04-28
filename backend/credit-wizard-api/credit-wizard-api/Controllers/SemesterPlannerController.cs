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
    public class SemesterPlannerController : Controller
    {
        private readonly ISemesterPlannerService _semesterPlannerService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public SemesterPlannerController(ISemesterPlannerService semesterPlannerService, IUserService userService, IMapper mapper)
        {
            _semesterPlannerService = semesterPlannerService;
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Get all planned semester for logged in user
        /// </summary>
        /// <returns>List ofSemesterPlannerDto with the provided data</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SemesterPlannerDto>))]
        public async Task<IActionResult> GetByUserAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAsync(Guid.Parse(userId));

            return Ok(_mapper.Map<List<SemesterPlannerDto>>(data));
        }

        /// <summary>
        /// Create a new SemesterPlanner for logged in User
        /// </summary>
        /// <param name="dto">Data of Tyoe SemesterplannerDto</param>
        /// <returns>Amount of added Objects to the database</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateSemesterPlannerAsync(SemesterPlannerDto dto)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (dto.UserId != Guid.Parse(userId)) return BadRequest(new ErrorResultDto { ErrorType = nameof(BadRequest), StatusCode = 400, Message = "Parsed UserId does not match with the logged in user" });

            var created = await _semesterPlannerService.CreateAsync(_mapper.Map<SemesterPlanner>(dto));
            return Ok(created);
        }

        /// <summary>
        /// Edits a new SemesterPlanner for logged in User
        /// </summary>
        /// <param name="dto">Data of Tyoe SemesterplannerDto</param>
        /// <returns>Amount of edited Objects to the database</returns>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResultDto))]
        public async Task<IActionResult> UpdateSemesterPlannerAsync(Guid id, SemesterPlannerDto dto)
        {
            if (id != dto.Id) return BadRequest(new ErrorResultDto { ErrorType = nameof(BadRequest), Message = "One of the parsed id does not match with de id from the request body", StatusCode = 400 });
            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if (dto.UserId != Guid.Parse(userId)) return BadRequest(new ErrorResultDto { ErrorType = nameof(BadRequest), StatusCode = 400, Message = "Parsed UserId does not match with the logged in user" });

            var data = await _semesterPlannerService.GetByIdAndUserIdAsync(id, Guid.Parse(userId));
            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });

            var updated = await _semesterPlannerService.UpdateAsync(_mapper.Map<SemesterPlanner>(dto));
            return Ok(updated);
        }


        /// <summary>
        /// Delete planned Semester from user
        /// </summary>
        /// <param name="id">Id of the deleted SemesterPlanner</param>
        /// <returns>Amount of deleted Objects to the database</returns>
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        public async Task<IActionResult> DeleteSemesterPlannerAsync(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByIdAndUserIdAsync(id, Guid.Parse(userId));

            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });

            var delete = await _semesterPlannerService.DeleteAsync(data.Id);
            return Ok(delete);
        }
    }
}
