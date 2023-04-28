using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface ISemesterPlannerService
    {
        /// <summary>
        /// Get all Semesterplanner by its user
        /// </summary>
        /// <param name="userId">id of the logged in user</param>
        /// <returns>list of all Semesterplanner</returns>
        public Task<List<SemesterPlanner>> GetByUserIdAsync(Guid userId);

        /// <summary>
        /// Check if the semesterplannerId belongs to the user
        /// </summary>
        /// <param name="userId">id of the logged in user</param>
        /// <param name="semesterPlannerId">id of the semesterplanner object which should be checked</param>
        /// <returns>true if the checked semesterplanner belongs to the user</returns>
        public Task<bool> IsUsersPlannedSemester(Guid userId, Guid semesterPlannerId);

        /// <summary>
        /// Get a Semesterplanner object by its id and user id
        /// </summary>
        /// <param name="userId">id of the logged in user</param>
        /// <param name="id">id of the semesterplanner object which should be checked</param>
        /// <returns>object if found otherwise null</returns>
        public Task<SemesterPlanner?> GetByIdAndUserIdAsync(Guid id, Guid userId);

        /// <summary>
        /// Get etcs points for completed modul. 
        /// A modul only counts in if Semesterplanner is completed and grade is larger or equal to 4
        /// </summary>
        /// <param name="data">list ob object which should be evaluated</param>
        /// <returns>number of reached etcs points</returns>
        public int GetCompletedEctsPointsByUserAsync(List<SemesterPlanner> data);

        /// <summary>
        /// Get etcs points which are currently open.
        /// This only occurs if the according semesterplanner is not completed yet
        /// The graded do not matter for this result
        /// </summary>
        /// <param name="data">list ob object which should be evaluated</param>
        /// <returns>number of open etcs points</returns>
        public int GetOpenEctsPointsByUserAsync(List<SemesterPlanner> data);

        /// <summary>
        /// Indicates how many etcs points have been lost to failure
        /// </summary>
        /// <param name="data">list ob object which should be evaluated</param>
        /// <returns>number of missed etcs points</returns>
        public int GetMissedEctsPointsByUserAsync(List<SemesterPlanner> data);

        /// <summary>
        /// Indicates how many percent of required modules have been reached.
        /// A modul only counts in if Semesterplanner is completed and grade is larger or equal to 4
        /// </summary>
        /// <param name="data"></param>
        /// <param name="degreeId"></param>
        /// <returns></returns>
        public Task<int> GetPercentageFinishedRequiredModulsByUserAsync(List<SemesterPlanner> data, Guid degreeId);

        /// <summary>
        /// Add a new Semesterplanner for user
        /// </summary>
        /// <param name="semesterPlanner">object of the new added data</param>
        /// <returns>integer which indicates how many elements have been added to the database</returns>
        public Task<int> CreateAsync(SemesterPlanner semesterPlanner);

        /// <summary>
        /// Edit a new Semesterplanner for user
        /// </summary>
        /// <param name="semesterPlanner">object of the edited data</param>
        /// <returns>integer which indicates how many elements have been added to the database</returns>
        public Task<int> UpdateAsync(SemesterPlanner semesterPlanner);

        /// <summary>
        /// Delete a new Semesterplanner for user
        /// </summary>
        /// <param name="id">if of the object which should be deleted</param>
        /// <returns>integer which indicates how many elements have been added to the database</returns>
        public Task<int> DeleteAsync(Guid id);
    }
}
