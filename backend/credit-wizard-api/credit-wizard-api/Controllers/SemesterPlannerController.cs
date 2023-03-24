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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUserAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAsync(Guid.Parse(userId));
            
            return Ok(data.Select(x => new SemesterPlannerDto
            {
                Id = x.Id,
                SemesterId = x.Semester.Id,
                SemesterDto = new SemesterDto
                {
                    Id = x.Semester.Id,
                    Number = x.Semester.Number
                },
                SemesterPlannerModulDtos = x.SemesterPlannerModuls.Select(y => new SemesterPlannerModulDto
                {
                    SemesterPlannerId = y.SemesterPlannerId,
                    ModulId = y.ModulId,
                    ModulDto = new ModulDto
                    {
                        Id = y.ModulId,
                        Name = y.Modul.Name,
                        Abbreviation = y.Modul.Abbreviation,
                        Description = y.Modul.Description
                    },
                    Grade = y.Grade
                }).ToList(),
                UserId = x.UserId
            }));
        }

        [HttpGet("{semesterId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUserAndSemesterIdAsync(Guid semesterId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAndSemesterIdAsync(Guid.Parse(userId), semesterId);

            if (data == null) return NotFound("There is no matching entry");

            return Ok(new SemesterPlannerDto
            {
                Id = data.Id,
                SemesterId = data.Semester.Id,
                SemesterDto = new SemesterDto
                {
                    Id = data.Semester.Id,
                    Number = data.Semester.Number
                },
                SemesterPlannerModulDtos = data.SemesterPlannerModuls.Select(y => new SemesterPlannerModulDto
                {
                    SemesterPlannerId = y.SemesterPlannerId,
                    ModulId = y.ModulId,
                    ModulDto = new ModulDto
                    {
                        Id = y.ModulId,
                        Name = y.Modul.Name,
                        Abbreviation = y.Modul.Abbreviation,
                        Description = y.Modul.Description
                    },
                    Grade = y.Grade
                }).ToList(),
                UserId = data.UserId
            });
        }

        [HttpGet("{semesterNumber:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUserAndSemesterNumberAsync(int semesterNumber)
        {
            if (semesterNumber == 0 || semesterNumber > 100) return BadRequest("Die eingegebene Semester Nummer ist ungültig");            

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var data = await _semesterPlannerService.GetByUserIdAndSemesterNumberAsync(Guid.Parse(userId), semesterNumber);

            if (data == null) return NotFound("There is no matching entry");

            return Ok(new SemesterPlannerDto
            {
                Id = data.Id,
                SemesterId = data.Semester.Id,
                SemesterDto = new SemesterDto
                {
                    Id = data.Semester.Id,
                    Number = data.Semester.Number
                },
                SemesterPlannerModulDtos = data.SemesterPlannerModuls.Select(y => new SemesterPlannerModulDto
                {
                    SemesterPlannerId = y.SemesterPlannerId,
                    ModulId = y.ModulId,
                    ModulDto = new ModulDto
                    {
                        Id = y.ModulId,
                        Name = y.Modul.Name,
                        Abbreviation = y.Modul.Abbreviation,
                        Description = y.Modul.Description
                    },
                    Grade = y.Grade
                }).ToList(),
                UserId = data.UserId
            });
        }
    }
}
