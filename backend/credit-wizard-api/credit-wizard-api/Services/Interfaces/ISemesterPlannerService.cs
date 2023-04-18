using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface ISemesterPlannerService
    {
        public Task<List<SemesterPlanner>> GetByUserIdAsync(Guid userId);

        public Task<SemesterPlanner?> GetByUserIdAndSemesterIdAsync(Guid userId, Guid semesterId);

        public Task<SemesterPlanner?> GetByUserIdAndSemesterNumberAsync(Guid userId, int semesterNumber);
        public int GetCompletedEctsPointsByUserAsync(List<SemesterPlanner> data);

        public int GetOpenEctsPointsByUserAsync(List<SemesterPlanner> data);
        public int GetMissedEctsPointsByUserAsync(List<SemesterPlanner> data);

        public Task<int> GetPercentageFinishedRequiredModulsByUserAsync(List<SemesterPlanner> data, Guid degreeId);
    }
}
