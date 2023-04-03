using AutoMapper;
using credit_wizard_api.Dtos;
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
        private readonly IMapper _mapper;

        public DegreeController(IDegreeService degreeService, IMapper mapper)
        {
            _degreeService = degreeService;
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
    }
}
