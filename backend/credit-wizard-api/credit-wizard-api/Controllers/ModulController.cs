using AutoMapper;
using credit_wizard_api.Dtos;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace credit_wizard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ModulController : Controller
    {

        private readonly IModulService _modulService;
        private readonly IMapper _mapper;

        public ModulController(IModulService modulService, IMapper mapper)
        {
            _modulService = modulService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Moduls
        /// </summary>
        /// <returns>A List of all Modules form of a ModulDto List</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_mapper.Map<List<ModulDto>>(await _modulService.GetAsync()));
        }

        /// <summary>
        /// Get specific Modul by its id
        /// </summary>
        /// <param name="id">Id of the searched Modul</param>
        /// <returns>A Modul in form of a ModulDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(_mapper.Map<ModulDto>(await _modulService.GetByIdAsync(id)));
        }
    }
}
