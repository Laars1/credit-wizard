using credit_wizard_api.Dtos;
using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    public Task<bool> UserExistsAsync(Guid userId);
    public Task<User?> GetByIdWithDependenciesAsync(Guid id);
    public Task<User?> GetByNameAsync(string username);
    public Task<List<string>> GetRolesFromUserAsync(string username);
    public Task<DegreeProgressDto> GetCurrentDegreeProgress(Guid userId);
}