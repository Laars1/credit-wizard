using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class SemesterPlannerService : ISemesterPlannerService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;


        public SemesterPlannerService(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<List<SemesterPlanner>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.SemesterPlanners.Where(x => x.UserId == userId)
                .Include(x => x.Semester)
                .Include(x => x.SemesterPlannerModuls)
                .ThenInclude(x => x.Modul)
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


    }
}
