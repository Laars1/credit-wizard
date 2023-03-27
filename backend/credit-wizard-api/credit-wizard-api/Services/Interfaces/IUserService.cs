using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    public Task<User?> GetByNameAsync(string username);
    public Task<List<string>> GetRolesFromUserAsync(string username);
}