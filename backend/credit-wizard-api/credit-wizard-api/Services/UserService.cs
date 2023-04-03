using System.Net.Mime;
using credit_wizard_api.Exceptions;
using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UserService(ApplicationDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    
    public async Task<List<User>> GetAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
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
}