using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface IDegreeService : IBaseService<Degree>
    {
        /// <summary>
        /// Get degree by its id, with included DegreeModules and Modules
        /// </summary>
        /// <param name="id">id of the degree</param>
        /// <returns>Degree if found, otherwise null</returns>
        public Task<Degree?> GetByIdWithModulesAsync(Guid id);

        /// <summary>
        /// Get all DegreeModules by passed timeslot and degree-id
        /// </summary>
        /// <param name="id">id of the degree</param>
        /// <param name="timeslotId">id of the timeslot</param>
        /// <returns>Degreemodul list</returns>
        public Task<List<DegreeModul>> GetByIdWithModulesByTimeslotAsync(Guid id, Guid timeslotId);

        /// <summary>
        /// Check if passed modul is part of 
        /// </summary>
        /// <param name="modulId">id of the checked modul</param>
        /// <param name="degreeId">id of the checked degree</param>
        /// <returns>true if modul is part of degree</returns>
        public Task<bool> IsModulPartOfDegreeAsync(Guid modulId, Guid degreeId);
    }
}
