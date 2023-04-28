using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    /// <summary>
    /// Business logic for modules, method comments are placed in its interface
    /// </summary>
    public class ModulService : IModulService
    {
        private readonly ApplicationDbContext _dbContext;
        public ModulService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Modul>> GetAsync()
        {
            return await _dbContext.Moduls
                .Include(x => x.SemesterTimeSlot)
                .Include(x => x.DegreeModuls).ThenInclude(x => x.Degree)
                .Select(x => new Modul
                {
                    Id = x.Id,
                    SemesterTimeSlot = x.SemesterTimeSlot.Select(y => new SemesterTimeSlot { Id = y.Id, Timeslot = y.Timeslot }).ToList(),
                    Abbreviation = x.Abbreviation,
                    Description = x.Description,
                    EtcsPoints = x.EtcsPoints,
                    Name = x.Name,
                    DegreeModuls = x.DegreeModuls.Select(y => new DegreeModul { DegreeId = y.DegreeId, IsRequired = y.IsRequired, Degree = y.Degree }).ToList(),
                })
                .ToListAsync();
        }

        public async Task<Modul?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Moduls
                .Include(x => x.SemesterTimeSlot)
                .Include(x => x.DegreeModuls).ThenInclude(x => x.Degree)
                .Select(x => new Modul
                {
                    Id = x.Id,
                    SemesterTimeSlot = x.SemesterTimeSlot.Select(y => new SemesterTimeSlot { Id = y.Id, Timeslot = y.Timeslot }).ToList(),
                    Abbreviation = x.Abbreviation,
                    Description = x.Description,
                    EtcsPoints = x.EtcsPoints,
                    Name = x.Name,
                    DegreeModuls = x.DegreeModuls.Select(y => new DegreeModul { DegreeId = y.DegreeId, IsRequired = y.IsRequired, Degree = y.Degree }).ToList(),
                })
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
