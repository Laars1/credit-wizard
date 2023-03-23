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

        public async Task<List<Degree>> GetAsync()
        {
            return await _dbContext.Degrees.ToListAsync();
        }

        public async Task<Degree?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Degrees.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
