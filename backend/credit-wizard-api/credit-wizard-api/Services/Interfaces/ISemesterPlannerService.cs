using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface ISemesterPlannerService
    {
        public Task<List<SemesterPlanner>> GetByUserIdAsync(Guid userId);

        public Task<SemesterPlanner?> GetByUserIdAndSemesterIdAsync(Guid userId, Guid semesterId);

        public Task<SemesterPlanner?> GetByUserIdAndSemesterNumberAsync(Guid userId, int semesterNumber);
    }
}
