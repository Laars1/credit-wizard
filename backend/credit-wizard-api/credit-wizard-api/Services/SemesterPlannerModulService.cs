using credit_wizard_api.Exceptions;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class SemesterPlannerModulService : ISemesterPlannerModulService
    {
        private readonly ApplicationDbContext _dbContext;

        public SemesterPlannerModulService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(SemesterPlannerModul semesterPlannerModul)
        {
            if (await ExistsAsync(semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId))
            {
                throw new EntityAlreadyExistsException(nameof(SemesterPlannerModul), nameof(SemesterPlannerModul.ModulId), nameof(SemesterPlannerModul.SemesterPlannerId));
            }

            _dbContext.SemesterPlannerModuls.Add(semesterPlannerModul);
            return await _dbContext.SaveChangesAsync();

        }

        public Task<int> DeleteAsync(Guid modulId, Guid semesterPlannerId)
        {
            throw new NotImplementedException();
        }


        public async Task<SemesterPlannerModul?> GetByIdAsync(Guid modulId, Guid semesterPlannerId)
        {
            return await _dbContext.SemesterPlannerModuls.FirstOrDefaultAsync(x => x.ModulId == modulId && x.SemesterPlannerId == semesterPlannerId);
        }

        public async Task<List<SemesterPlannerModul>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.SemesterPlannerModuls.Include(x => x.SemesterPlanner).Where(x => x.SemesterPlanner.UserId == userId).ToListAsync();
        }

        public Task<int> UpdateAsync(SemesterPlannerModul semesterPlannerModul)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> AlreadyCompletedModul(Guid userId, Guid modulId, Guid semesterPlannerId)
        {
            return await _dbContext.SemesterPlannerModuls
                .Include(x => x.SemesterPlanner)
                .AnyAsync(x => 
                    x.SemesterPlanner.UserId == userId &&
                    x.ModulId == modulId &&
                    x.SemesterPlannerId != semesterPlannerId &&
                    x.Grade >= 4);
        }

        public async Task<bool> ExistsAsync(Guid modulId, Guid semesterPlannerId)
        {
            return await _dbContext.SemesterPlannerModuls.AnyAsync(x => x.ModulId == modulId && x.SemesterPlannerId == semesterPlannerId);
        }

    }
}
