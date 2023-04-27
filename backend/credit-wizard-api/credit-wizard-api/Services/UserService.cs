using System.Net.Mime;
using credit_wizard_api.Dtos;
using credit_wizard_api.Exceptions;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace credit_wizard_api.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly ISemesterPlannerService _semesterPlannerService;

    public UserService(ApplicationDbContext dbContext, UserManager<User> userManager, ISemesterPlannerService semesterPlannerService)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _semesterPlannerService = semesterPlannerService;
    }
    
    public async Task<List<User>> GetAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users
            .Include(x => x.Degree)
            .FirstOrDefaultAsync(x => x.Id == id);

    }
    
    public async Task<User?> GetByIdWithDependenciesAsync(Guid id)
    {
        return await _dbContext.Users
            .Include(x => x.Degree)
            .Include(x => x.SemesterPlanners)
            .ThenInclude(x => x.Semester)
            .Include(x => x.SemesterPlanners)
            .ThenInclude(x => x.SemesterPlannerModuls)
            .ThenInclude(x => x.Modul)
            .ThenInclude(x => x.SemesterTimeSlot)
            .FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<User?> GetByNameAsync(string username)
    {
        return await _userManager.FindByEmailAsync(username);
    }

    public async Task<List<string>> GetRolesFromUserAsync(string username)
    {
        var user = await GetByNameAsync(username);

        if (user == null) throw new EntityNotFoundException(nameof(User), nameof(User.UserName), username);

        return (await _userManager.GetRolesAsync(user)).ToList();
    }

    public async Task<DegreeProgressDto> GetCurrentDegreeProgress(Guid userId)
    {
        var currentUser = await GetByIdWithDependenciesAsync(userId);
        if (currentUser == null) throw new EntityNotFoundException("User", "Id", userId.ToString());

        var total = currentUser.Degree.TotalEtcsPoints;
        var reached = _semesterPlannerService.GetCompletedEctsPointsByUserAsync(currentUser.SemesterPlanners.ToList());
        var open = _semesterPlannerService.GetOpenEctsPointsByUserAsync(currentUser.SemesterPlanners.ToList());
        var progress = new DegreeProgressDto
        {
            UserId = currentUser.Id,
            TotalDegreeEtcsPoints = total,
            ReachedEtcsPoints = reached,
            OpenEtcsPoints = open,
            MissedEctsPoints = _semesterPlannerService.GetMissedEctsPointsByUserAsync(currentUser.SemesterPlanners.ToList()),
            MissingEtcsPoints = total - reached - open,
            PercentageFinishedRequiredModuls = await _semesterPlannerService.GetPercentageFinishedRequiredModulsByUserAsync(currentUser.SemesterPlanners.ToList(), currentUser.DegreeId)
        };
        return progress;
    }

    public async Task<bool> UserExistsAsync(Guid userId)
    {
        return await _dbContext.Users.AnyAsync(x => x.Id == userId);
    }

    public async Task<Degree?> GetUsersDegreeAsync(Guid userId)
    {
        return await _dbContext.Users.Include(x => x.Degree).Select(x => x.Degree).FirstOrDefaultAsync(x => x.Id == userId);
    }
}