using credit_wizard_api.Exceptions;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class SemesterPlannerService : ISemesterPlannerService
    {
        private readonly UserManager<User> _userManager;
        private readonly IDegreeService _degreeService;
        private readonly ApplicationDbContext _dbContext;


        public SemesterPlannerService(ApplicationDbContext dbContext, UserManager<User> userManager, IDegreeService degreeService)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _degreeService = degreeService;
        }

        public async Task<List<SemesterPlanner>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.SemesterPlanners.Where(x => x.UserId == userId)
                .Include(x => x.Semester)
                .Include(x => x.SemesterPlannerModuls)
                .ThenInclude(x => x.Modul)
                .ThenInclude(x => x.SemesterTimeSlot)
                .ToListAsync();
        }

        public async Task<SemesterPlanner?> GetByUserIdAndSemesterIdAsync(Guid userId, Guid semesterId)
        {
            return await _dbContext.SemesterPlanners
                .Include(x => x.Semester)
                .Include(x => x.SemesterPlannerModuls)
                .ThenInclude(x => x.Modul)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.SemesterId == semesterId);
        }

        public async Task<SemesterPlanner?> GetByUserIdAndSemesterNumberAsync(Guid userId, int semesterNumber)
        {
            return await _dbContext.SemesterPlanners
                .Include(x => x.Semester)
                .Include(x => x.SemesterPlannerModuls)
                .ThenInclude(x => x.Modul)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Semester.Number == semesterNumber);
        }

        public int GetCompletedEctsPointsByUserAsync(List<SemesterPlanner> data)
        {
            if (!data.Any()) return 0;
            var sum = 0;
            var completedModules = data.Where(x => x.Completed).SelectMany(x => x.SemesterPlannerModuls).ToList();
            completedModules
                .Where(x => x.Grade >= 4)
                .Select(x => x.Modul.EtcsPoints).ToList()
                .ForEach(x => sum += x);
            return sum;
        }
        
        public int GetOpenEctsPointsByUserAsync(List<SemesterPlanner> data)
        {
            if (!data.Any()) return 0;
            var sum = 0;
            var openModules = data.Where(x => !x.Completed).SelectMany(x => x.SemesterPlannerModuls).ToList();
            openModules
                .Select(x => x.Modul.EtcsPoints).ToList()
                .ForEach(x => sum += x);
            return sum;
        }
        
        public int GetMissedEctsPointsByUserAsync(List<SemesterPlanner> data)
        {
            if (!data.Any()) return 0;
            var sum = 0;
            var openModules = data.Where(x => x.Completed).SelectMany(x => x.SemesterPlannerModuls).ToList();
            openModules
                .Where(x => x.Grade < 4)
                .Select(x => x.Modul.EtcsPoints).ToList()
                .ForEach(x => sum += x);
            return sum;
        }
        
        public async Task<int> GetPercentageFinishedRequiredModulsByUserAsync(List<SemesterPlanner> data, Guid degreeId)
        {
            if (!data.Any()) return 0;
            var degree = await _degreeService.GetByIdWithModulesAsync(degreeId);

            if (degree == null)
                throw new EntityNotFoundException(nameof(Degree), nameof(Degree.Id), degreeId.ToString());
            var requiredModulIds = degree.DegreeModuls.Where(x => x.IsRequried).Select(x => x.Modul.Id).ToList();
            var finishedSemesterPlannerModuls = data.Where(x => x.Completed).SelectMany(x => x.SemesterPlannerModuls).ToList();
            var finishedModulesId = finishedSemesterPlannerModuls.Where(x => x.Grade >= 4).Select(x => x.ModulId);
            var completed = finishedModulesId.Count(x => requiredModulIds.Contains(x));
            return 100 / requiredModulIds.Count * completed;

        }
    }
}