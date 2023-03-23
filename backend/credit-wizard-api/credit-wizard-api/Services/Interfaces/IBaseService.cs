namespace credit_wizard_api.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        public Task<List<T>> GetAsync();

        public Task<T?> GetByIdAsync(Guid id);
    }
}
