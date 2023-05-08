using credit_wizard_api.Exceptions;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    /// <summary>
    /// Business logic for SemesterPlannerModul, public method comments are placed in its interface
    /// </summary>
    public class SemesterPlannerModulService : ISemesterPlannerModulService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDegreeService _degreeService;
        private readonly IModulService _modulService;
        private readonly IUserService _userService;
        private readonly ISemesterPlannerService _semesterPlannerService;

        public SemesterPlannerModulService(ApplicationDbContext dbContext, IDegreeService degreeService, IModulService modulService, IUserService userService, ISemesterPlannerService semesterPlannerService)
        {
            _dbContext = dbContext;
            _degreeService = degreeService;
            _modulService = modulService;
            _userService = userService;
            _semesterPlannerService = semesterPlannerService;
        }

        public async Task<SemesterPlannerModul?> GetByIdAsync(Guid modulId, Guid semesterPlannerId)
        {
            return await _dbContext.SemesterPlannerModuls.FirstOrDefaultAsync(x => x.ModulId == modulId && x.SemesterPlannerId == semesterPlannerId);
        }

        public async Task<List<SemesterPlannerModul>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.SemesterPlannerModuls.Include(x => x.SemesterPlanner).Where(x => x.SemesterPlanner.UserId == userId).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid modulId, Guid semesterPlannerId)
        {
            return await _dbContext.SemesterPlannerModuls.AnyAsync(x => x.ModulId == modulId && x.SemesterPlannerId == semesterPlannerId);
        }

        public async Task<int> CreateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId)
        {
            await ValidateUserIdAndSemesterId(userId, semesterPlannerModul.SemesterPlannerId);
            await ValidateModulId(userId, semesterPlannerModul.ModulId);
            await ValidateSemesterPlannerModulDoesNotExist(semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId);
            await ValidateModulNotAlreadyCompleted(userId, semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId);

            _dbContext.SemesterPlannerModuls.Add(semesterPlannerModul);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId)
        {
            await ValidateUserIdAndSemesterId(userId, semesterPlannerModul.SemesterPlannerId);
            await ValidateModulId(userId, semesterPlannerModul.ModulId);
            await ValidateModulNotAlreadyCompleted(userId, semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId);

            var item = await GetByIdAsync(semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId);
            if (item == null) throw new EntityNotFoundException($"No SemesterPlannerModul found with SemesterPlannerId {semesterPlannerModul.SemesterPlanner} & ModulId {semesterPlannerModul.ModulId}");

            item.Grade = semesterPlannerModul.Grade;

            _dbContext.SemesterPlannerModuls.Update(item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid modulId, Guid semesterPlannerId, Guid userId)
        {
            await ValidateUserIdAndSemesterId(userId, semesterPlannerId);

            var toDelete = await GetByIdAsync(modulId, semesterPlannerId);
            if (toDelete == null) throw new EntityNotFoundException($"No SemesterPlannerModul found with SemesterPlannerId {semesterPlannerId} & ModulId {modulId}");

            _dbContext.SemesterPlannerModuls.Remove(toDelete);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SemesterPlannerModul>> GetCompletedModulesByUser(Guid userId)
        {
            return await _dbContext.SemesterPlannerModuls.Include(x => x.SemesterPlanner).Where(x => x.SemesterPlanner.UserId == userId && x.Grade >= 4).ToListAsync() ?? new List<SemesterPlannerModul>();
        }

        /// <summary>
        /// Check if modul is already completed
        /// </summary>
        /// <param name="userId">id of the checked user</param>
        /// <param name="modulId">id of the checked modul</param>
        /// <param name="semesterPlannerId">id of the checked semesterplanner</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Validates that the provided user ID corresponds to a planned semester with the provided semester planner ID.
        /// Throws an EntityNotFoundException if no matching planned semester is found.
        /// </summary>
        /// <param name="userId">The ID of the user to validate.</param>
        /// <param name="semesterPlannerId">The ID of the semester planner to </param>
        /// <exception cref="EntityNotFoundException">when no entity is found</exception>
        private async Task ValidateUserIdAndSemesterId(Guid userId, Guid semesterPlannerId)
        {
            if (!await _semesterPlannerService.IsUsersPlannedSemester(userId, semesterPlannerId))
            {
                throw new EntityNotFoundException($"User with Id {userId} has no matching planned semester with Id {semesterPlannerId}");
            }
        }
        
        /// <summary>
        /// Validates if a given module ID exists as part of the user's degree.
        /// </summary>
        /// <param name="userId">The ID of the user to validate.</param>
        /// <param name="modulId">The ID of the module to validate.</param>
        /// <exception cref="ReferenceNotExistsException">Thrown when the module ID does not exist as part of the user's degree.</exception>
        private async Task ValidateModulId(Guid userId, Guid modulId)
        {
            var degree = await _userService.GetUsersDegreeAsync(userId);
            if (!await _degreeService.IsModulPartOfDegreeAsync(modulId, degree.Id))
            {
                var modul = await _modulService.GetByIdAsync(modulId);
                throw new ReferenceNotExistsException(nameof(Degree), nameof(Modul), modul?.Name ?? modulId.ToString());
            }
        }
        
        /// <summary>
        /// Validates whether a semester planner module with the specified module ID and semester planner ID already exists.
        /// </summary>
        /// <param name="modulId">The ID of the module to validate.</param>
        /// <param name="semesterPlannerId">The ID of the semester planner to validate.</param>
        /// <exception cref="EntityAlreadyExistsException">if a matching semester planner module already exists.</exception>
        private async Task ValidateSemesterPlannerModulDoesNotExist(Guid modulId, Guid semesterPlannerId)
        {
            if (await ExistsAsync(modulId, semesterPlannerId))
            {
                throw new EntityAlreadyExistsException(nameof(SemesterPlannerModul), $"{nameof(SemesterPlannerModul.ModulId)} ({modulId})", $"{nameof(SemesterPlannerModul.SemesterPlannerId)} ({semesterPlannerId})");
            }
        }
        
        /// <summary>
        /// Validates if the modul with the given ID is not already completed by the user in the given semester planner.
        /// Throws an <see cref="EntityAlreadyCompletedException"/> if the modul is already completed.
        /// </summary>
        /// <param name="userId">The ID of the user to check for completion of the modul.</param>
        /// <param name="modulId">The ID of the modul to check for completion.</param>
        /// <param name="semesterPlannerId">The ID of the semester planner in which the modul is to be checked for completion.</param>
        /// <exception cref="EntityAlreadyCompletedException">Thrown when the modul is already completed by the user.</exception>
        private async Task ValidateModulNotAlreadyCompleted(Guid userId, Guid modulId, Guid semesterPlannerId)
        {
            if (await AlreadyCompletedModul(userId, modulId, semesterPlannerId))
            {
                var degree = await _userService.GetUsersDegreeAsync(userId);
                throw new EntityAlreadyCompletedException(nameof(SemesterPlannerModul), degree.Name);
            }
        }
    }
}
