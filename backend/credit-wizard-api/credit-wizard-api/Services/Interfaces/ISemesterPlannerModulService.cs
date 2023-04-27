using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface ISemesterPlannerModulService
    {
        public Task<List<SemesterPlannerModul>> GetByUserIdAsync(Guid userId);
        public Task<SemesterPlannerModul?> GetByIdAsync(Guid modulId, Guid semesterPlannerId);
        public Task<int> CreateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId);
        public Task<int> UpdateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId);
        public Task<int> DeleteAsync(Guid modulId, Guid semesterPlannerId, Guid userId);

        public Task<bool> ExistsAsync(Guid modulId, Guid semesterPlannerId);

    }
}
