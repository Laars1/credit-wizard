using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly ApplicationDbContext _dbContext;

        public DegreeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Degree>> GetAsync() => await _dbContext.Degrees.Include(x => x.DegreeModuls).ThenInclude(x => x.Modul).ToListAsync();

        public async Task<Degree?> GetByIdAsync(Guid id) => await _dbContext.Degrees.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Degree?> GetByIdWithModulesAsync(Guid id) => await _dbContext.Degrees.Include(x => x.DegreeModuls).ThenInclude(x => x.Modul).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> IsModulPartOfDegreeAsync(Guid modulId)
        {
            return await _dbContext.Degrees.Include(x => x.DegreeModuls).AnyAsync(x => x.DegreeModuls.Select(y => y.ModulId).Contains(modulId));
        }
    }
}
