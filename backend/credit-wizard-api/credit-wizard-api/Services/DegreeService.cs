using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    /// <summary>
    /// Business logic for degree, method comments are placed in its interface
    /// </summary>
    public class DegreeService : IDegreeService
    {
        private readonly ApplicationDbContext _dbContext;

        public DegreeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Degree>> GetAsync() => await _dbContext.Degrees.Include(x => x.DegreeModuls).ThenInclude(x => x.Modul).ToListAsync();

        public async Task<Degree?> GetByIdAsync(Guid id) => await _dbContext.Degrees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Degree?> GetByIdWithModulesAsync(Guid id) => await _dbContext.Degrees.Include(x => x.DegreeModuls).ThenInclude(x => x.Modul).ThenInclude(x => x.SemesterTimeSlot).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<DegreeModul>> GetByIdWithModulesByTimeslotAsync(Guid id, Guid timeslotId)
        {
            return await _dbContext.DegreeModuls
                .Include(x => x.Modul)
                .ThenInclude(x => x.SemesterTimeSlot)
                .Where(x => x.DegreeId == id && x.Modul.SemesterTimeSlot.Any(y => y.Id == timeslotId))
                .ToListAsync();
        }

        public async Task<bool> IsModulPartOfDegreeAsync(Guid modulId, Guid degreeId)
        {
            return await _dbContext.Degrees.Include(x => x.DegreeModuls).AnyAsync(x => x.Id == degreeId && x.DegreeModuls.Select(y => y.ModulId).Contains(modulId));
        }
    }
}
