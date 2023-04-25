using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface ISemesterPlannerService
    {
        public Task<List<SemesterPlanner>> GetByUserIdAsync(Guid userId);

        public Task<SemesterPlanner?> GetByIdAndUserIdAsync(Guid id, Guid userId);

        public int GetCompletedEctsPointsByUserAsync(List<SemesterPlanner> data);

        public int GetOpenEctsPointsByUserAsync(List<SemesterPlanner> data);
        public int GetMissedEctsPointsByUserAsync(List<SemesterPlanner> data);

        public Task<int> GetPercentageFinishedRequiredModulsByUserAsync(List<SemesterPlanner> data, Guid degreeId);

        public Task<int> CreateAsync(SemesterPlanner semesterPlanner);

        public Task<int> DeleteAsync(Guid id);
        public Task<int> UpdateAsync(SemesterPlanner semesterPlanner);
    }
}
