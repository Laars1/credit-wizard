using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Models;
using credit_wizard_api.Services;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SemesterPlannerModulController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISemesterPlannerModulService _semesterPlannerModulService;

        public SemesterPlannerModulController(IMapper mapper, ISemesterPlannerModulService semesterPlannerModulService)
        {
            _mapper = mapper;
            _semesterPlannerModulService = semesterPlannerModulService;
        }

        /// <summary>
        /// Get all planned modules for logged in user
        /// </summary>
        /// <returns>List of SemesterPlannerModulDto with the provided data</returns>
        [HttpGet("user/current")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SemesterPlannerModulDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        public async Task<IActionResult> GetByUserAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerModulService.GetByUserIdAsync(Guid.Parse(userId));

            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = $"There is no matching entry for type {nameof(SemesterPlannerModulDto)}", StatusCode = 404 });

            return Ok(_mapper.Map<List<SemesterPlannerModulDto>>(data));
        }

        [HttpGet("user/current/completed")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Guid>))]
        public async Task<IActionResult> GetCompletedModulesByUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var completedModules = await _semesterPlannerModulService.GetCompletedModulesByUser(Guid.Parse(userId));
            return Ok(completedModules.Select(x => x.ModulId).ToList());
        }

        /// <summary>
        /// Get element by it's ids
        /// </summary>
        /// <param name="semesterplannerId">Id of the used SemesterPlanner</param>
        /// <param name="modulid">Id of the used Modul</param>
        /// <returns>Amount of added Objects to the database</returns>
        [HttpGet("semesterplannerid={semesterplannerId:Guid}&modulid={modulid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SemesterPlannerModulDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]
        public async Task<IActionResult> GetByIdAsync(Guid semesterplannerId, Guid modulid)
        {
            var data = await _semesterPlannerModulService.GetByIdAsync(modulid, semesterplannerId);

            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = $"There is no matching entry for type {nameof(SemesterPlannerModulDto)}", StatusCode = 404 });

            return Ok(_mapper.Map<SemesterPlannerModulDto>(data));
        }

        /// <summary>
        /// Create a new SemesterPlannerModul for logged in User
        /// </summary>
        /// <param name="dto">Data of Tyoe SemesterplannerModulDto</param>
        /// <returns>Amount of added Objects to the database</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateSemesterPlannerAsync(SemesterPlannerModulDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var created = await _semesterPlannerModulService.CreateAsync(_mapper.Map<SemesterPlannerModul>(dto), Guid.Parse(userId));
            return Ok(created);
        }

        /// <summary>
        /// Edits a new SemesterPlannerModul for logged in User
        /// </summary>
        /// <param name="semesterplannerId">Id of the used SemesterPlanner</param>
        /// <param name="modulid">Id of the used Modul</param>
        /// <param name="dto">Data of Tyoe SemesterplannerModulDto</param>
        /// <returns>Amount of added Objects to the database</returns>
        [HttpPut("semesterplannerid={semesterplannerId:Guid}&modulid={modulid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> UpdateSemesterPlannerAsync(Guid semesterplannerId, Guid modulid, SemesterPlannerModulDto dto)
        {
            if (semesterplannerId != dto.SemesterPlannerId || modulid != dto.ModulId) return BadRequest(new ErrorResultDto { ErrorType = nameof(BadRequest), Message = "One of the parsed id does not match with de id from the request body", StatusCode = 400 });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var updated = await _semesterPlannerModulService.UpdateAsync(_mapper.Map<SemesterPlannerModul>(dto), Guid.Parse(userId));
            return Ok(updated);
        }

        /// <summary>
        /// Deletes a new SemesterPlannerModul for logged in User
        /// </summary>
        /// <param name="semesterplannerId">Id of the used SemesterPlanner</param>
        /// <param name="modulid">Id of the used Modul</param>
        /// <returns>Amount of deleted Objects to the database</returns>
        [HttpDelete("semesterplannerid={semesterplannerId:Guid}&modulid={modulid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> DeleteSemesterPlannerAsync(Guid semesterplannerId, Guid modulid)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var delete = await _semesterPlannerModulService.DeleteAsync(modulid, semesterplannerId, Guid.Parse(userId));
            return Ok(delete);
        }
    }
}
