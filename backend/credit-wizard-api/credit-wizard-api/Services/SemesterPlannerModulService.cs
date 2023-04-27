using credit_wizard_api.Exceptions;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
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

        public async Task<int> CreateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId)
        {
            if(!await _semesterPlannerService.IsUsersPlannedSemester(userId, semesterPlannerModul.SemesterPlannerId)){
                throw new EntityNotFoundException($"User with Id {userId} has no matching planned semester with Id {semesterPlannerModul.SemesterPlannerId}");
            }

            if (!await _degreeService.IsModulPartOfDegreeAsync(semesterPlannerModul.ModulId))
            {
                if (semesterPlannerModul.Modul == null)
                {
                    var modul = await _modulService.GetByIdAsync(semesterPlannerModul.ModulId);
                    throw new ReferenceNotExistsException(nameof(Degree), nameof(Modul), modul?.Name ?? semesterPlannerModul.ModulId.ToString());
                }
                throw new ReferenceNotExistsException(nameof(Degree), nameof(Modul), semesterPlannerModul.Modul!.Name);
            }

            if (await ExistsAsync(semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId))
            {
                throw new EntityAlreadyExistsException(nameof(SemesterPlannerModul), $"{nameof(SemesterPlannerModul.ModulId)} ({semesterPlannerModul.ModulId})", $"{nameof(SemesterPlannerModul.SemesterPlannerId)} ({semesterPlannerModul.SemesterPlannerId})");
            }

            if(await AlreadyCompletedModul(userId, semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId))
            {
                var degree = await _userService.GetUsersDegreeAsync(userId);
                throw new EntityAlreadyCompletedException(nameof(SemesterPlannerModul), degree!.Name);
            }

            _dbContext.SemesterPlannerModuls.Add(semesterPlannerModul);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(Guid modulId, Guid semesterPlannerId, Guid userId)
        {
            if (!await _semesterPlannerService.IsUsersPlannedSemester(userId, semesterPlannerId))
            {
                throw new EntityNotFoundException($"User with Id {userId} has no matching planned semester with Id {semesterPlannerId}");
            }

            var deleted = await GetByIdAsync(modulId, semesterPlannerId);
            if (deleted == null) throw new EntityNotFoundException($"No SemesterPlannerModul found with SemesterPlannerId {semesterPlannerId} & ModulId {modulId}");

            _dbContext.SemesterPlannerModuls.Remove(deleted);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<SemesterPlannerModul?> GetByIdAsync(Guid modulId, Guid semesterPlannerId)
        {
            return await _dbContext.SemesterPlannerModuls.FirstOrDefaultAsync(x => x.ModulId == modulId && x.SemesterPlannerId == semesterPlannerId);
        }

        public async Task<List<SemesterPlannerModul>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.SemesterPlannerModuls.Include(x => x.SemesterPlanner).Where(x => x.SemesterPlanner.UserId == userId).ToListAsync();
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

        public async Task<int> UpdateAsync(SemesterPlannerModul semesterPlannerModul, Guid userId)
        {
            if (!await _semesterPlannerService.IsUsersPlannedSemester(userId, semesterPlannerModul.SemesterPlannerId))
            {
                throw new EntityNotFoundException($"User with Id {userId} has no matching planned semester with Id {semesterPlannerModul.SemesterPlannerId}");
            }

            if (!await _degreeService.IsModulPartOfDegreeAsync(semesterPlannerModul.ModulId))
            {
                if (semesterPlannerModul.Modul == null)
                {
                    var modul = await _modulService.GetByIdAsync(semesterPlannerModul.ModulId);
                    throw new ReferenceNotExistsException(nameof(Degree), nameof(Modul), modul?.Name ?? semesterPlannerModul.ModulId.ToString());
                }
                throw new ReferenceNotExistsException(nameof(Degree), nameof(Modul), semesterPlannerModul.Modul!.Name);
            }


            if (await AlreadyCompletedModul(userId, semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId))
            {
                var degree = await _userService.GetUsersDegreeAsync(userId);
                throw new EntityAlreadyCompletedException(nameof(SemesterPlannerModul), degree!.Name);
            }

            var item = await GetByIdAsync(semesterPlannerModul.ModulId, semesterPlannerModul.SemesterPlannerId);

            if(item == null) throw new EntityNotFoundException($"No SemesterPlannerModul found with SemesterPlannerId {semesterPlannerModul.SemesterPlanner} & ModulId {semesterPlannerModul.ModulId}");


            item.Grade = semesterPlannerModul.Grade;

            _dbContext.SemesterPlannerModuls.Update(item);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
