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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateSemesterPlannerAsync(SemesterPlannerDto dto)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _userService.UserExistsAsync(Guid.Parse(userId));
            if (!data) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });

            var created = await _semesterPlannerService.CreateAsync(_mapper.Map<SemesterPlanner>(dto));
            return Ok(created);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        public async Task<IActionResult> UpdateSemesterPlannerAsync(Guid id, SemesterPlannerDto dto)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByIdAndUserIdAsync(id, Guid.Parse(userId));
            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });

            var updated = await _semesterPlannerService.UpdateAsync(_mapper.Map<SemesterPlanner>(dto));
            return Ok(updated);
        }


        /// <summary>
        /// Delete planned Semester from usser
        /// </summary>
        /// <param name="id">Id of the deleted SemesterPlanner</param>
        /// <returns>integer of success</returns>
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        public async Task<IActionResult> DeleteSemesterPlannerAsync(Guid id)
        {
            var validId = Guid.Empty;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByIdAndUserIdAsync(id, Guid.Parse(userId));

            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });

            var delete = await _semesterPlannerService.DeleteAsync(data.Id);
            return Ok(delete);
        }
    }
}
