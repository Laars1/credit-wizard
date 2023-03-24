using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class ModulService : IModulService
    {
        private readonly ApplicationDbContext _dbContext;
        public ModulService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Modul>> GetAsync() => await _dbContext.Moduls.ToListAsync();

        public async Task<Modul?> GetByIdAsync(Guid id) => await _dbContext.Moduls.FirstOrDefaultAsync(x => x.Id == id);
    }
}
