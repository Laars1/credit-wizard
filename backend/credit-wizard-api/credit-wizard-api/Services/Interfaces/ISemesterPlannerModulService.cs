using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface ISemesterPlannerModulService
    {
        /// <summary>
        /// Get all Semesterplannermodules by its user
        /// </summary>
        /// <param name="userId">id of the logged in user</param>
        /// <returns>list of all Semesterplannermodules</returns>
        public Task<List<SemesterPlannerModul>> GetByUserIdAsync(Guid userId);

        /// <summary>
        /// Get Semesterplannermodul by its primary-keys
        /// </summary>
        /// <param name="modulId">id of the parsed modul</param>
        /// <param name="semesterPlannerId">id of the parsed semesterplanner</param>
        /// <returns>if found its SemesterPlannerModul otherwise null</returns>
        public Task<SemesterPlannerModul?> GetByIdAsync(Guid modulId, Guid semesterPlannerId);

        /// <summary>
        /// Add a new SemesterplannerModul to a Semesterplanner for logged in user
        /// </summary>
        /// <param name="semesterPlannerModul">object of the new added data</param>
        /// <param name="userId">id of the logged in user</param>
        /// <returns>integer which indicates how many elements have been added to the database</returns>
        public Task<int> CreateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId);

        /// <summary>
        /// Update an existing semesterplannermodul for logged in user
        /// </summary>
        /// <param name="semesterPlannerModul">object which should be edited</param>
        /// <param name="userId">id of the logged in user</param>
        /// <returns>integer which indicates how many elements have been added to the database</returns>
        public Task<int> UpdateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId);

        /// <summary>
        /// Delete an existing semesterplannermodul for logged in user
        /// </summary>
        /// <param name="modulId">id of the parsed modul</param>
        /// <param name="semesterPlannerId">id of the parsed semesterplanner</param>
        /// <param name="userId">id of the logged in user</param>
        /// <returns>integer which indicates how many elements have been added to the database</returns>
        public Task<int> DeleteAsync(Guid modulId, Guid semesterPlannerId, Guid userId);

        /// <summary>
        /// Check if there is already a reference with the same primary keys
        /// </summary>
        /// <param name="modulId">id of the parsed modul</param>
        /// <param name="semesterPlannerId">id of the parsed semesterplanner</param>
        /// <returns>true if there is an matching entry</returns>
        public Task<bool> ExistsAsync(Guid modulId, Guid semesterPlannerId);

        /// <summary>
        /// Get all SemesterPlannerModul from a user where its grade is larged or equal to 4
        /// </summary>
        /// <param name="userId">id of the logged in user</param>
        /// <returns>List of all completed SemesterPlannerModul</returns>
        public Task<List<SemesterPlannerModul>> GetCompletedModulesByUser(Guid userId);
    }
}
