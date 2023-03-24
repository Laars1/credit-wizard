using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ApplicationDbContext _dbContext;
        public SemesterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Semester>> GetAsync() => await _dbContext.Semesters.ToListAsync();

        public async Task<Semester?> GetByIdAsync(Guid id) => await _dbContext.Semesters.FirstOrDefaultAsync(x => x.Id == id);
    }
}
