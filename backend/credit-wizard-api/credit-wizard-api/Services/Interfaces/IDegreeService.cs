using credit_wizard_api.Models;

namespace credit_wizard_api.Services.Interfaces
{
    public interface IDegreeService : IBaseService<Degree>
    {
        public Task<Degree?> GetByIdWithModulesAsync(Guid id);

        public Task<bool> IsModulPartOfDegreeAsync(Guid modulId);
    }
}
