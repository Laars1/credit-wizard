using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SemesterTimeSlotController : Controller
    {

        private readonly ISemesterTimeSlotService _semesterTimeSlotService;
        private readonly IMapper _mapper;

        public SemesterTimeSlotController(ISemesterTimeSlotService semesterTimeSlotService, IMapper mapper)
        {
            _semesterTimeSlotService = semesterTimeSlotService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Semesters
        /// </summary>
        /// <returns>All Semesters in from of a List SemesterDto</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SemesterTimeSlotDto>))]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_mapper.Map<List<SemesterTimeSlotDto>>(await _semesterTimeSlotService.GetAsync()));
        }

        /// <summary>
        /// Get specific Semester by its id
        /// </summary>
        /// <param name="id">Id of the searched Semester</param>
        /// <returns>A Semester in form of a SemesterDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SemesterTimeSlotDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResultDto))]

        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var data = await _semesterTimeSlotService.GetByIdAsync(id);

            if (data == null) return NotFound(new ErrorResultDto { ErrorType = nameof(NotFound), Message = "There is no matching entry", StatusCode = 404 });

            return Ok(_mapper.Map<SemesterTimeSlotDto>(data));
        }
    }
}
