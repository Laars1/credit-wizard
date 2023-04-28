using credit_wizard_api.Dtos;
using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces;

public interface IUserService : IBaseService<User>
{
    /// <summary>
    /// Get user by its id with all includes
    /// </summary>
    /// <param name="id">id of the user</param>
    /// <returns>if found a user with all its dependencies</returns>
    public Task<User?> GetByIdWithDependenciesAsync(Guid id);

    /// <summary>
    /// Get user by its username -> email-address
    /// </summary>
    /// <param name="username">string of the name which should be checked</param>
    /// <returns>if found user, otherwise null</returns>
    public Task<User?> GetByNameAsync(string username);

    /// <summary>
    /// Get all roles from user by its username
    /// </summary>
    /// <param name="username">string of the name which should be checked</param>
    /// <returns>List of string with the matching roles</returns>
    public Task<List<string>> GetRolesFromUserAsync(string username);

    /// <summary>
    /// Get degree which user is currently doing
    /// </summary>
    /// <param name="userId">id which should be checked</param>
    /// <returns>if found degree, otherwise null</returns>
    public Task<Degree?> GetUsersDegreeAsync(Guid userId);

    /// <summary>
    /// Get current degreeprocess by userid
    /// </summary>
    /// <param name="userId">id which should be checked</param>
    /// <returns>object</returns>
    public Task<DegreeProgressDto> GetCurrentDegreeProgress(Guid userId);
}