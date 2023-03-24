using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SemesterController : Controller
    {

        private readonly ISemesterService _semesterService;
        private readonly IMapper _mapper;

        public SemesterController(ISemesterService semesterService, IMapper mapper)
        {
            _semesterService = semesterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Semesters
        /// </summary>
        /// <returns>All Semesters in from of a List SemesterDto</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_mapper.Map<List<SemesterDto>>(await _semesterService.GetAsync()));
        }

        /// <summary>
        /// Get specific Semester by its id
        /// </summary>
        /// <param name="id">Id of the searched Semester</param>
        /// <returns>A Semester in form of a SemesterDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(_mapper.Map<SemesterDto>(await _semesterService.GetByIdAsync(id)));
        }
    }
}
