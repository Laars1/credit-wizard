namespace credit_wizard_api.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Get all items from T
        /// </summary>
        /// <returns>A lsit from all items (T)</returns>
        public Task<List<T>> GetAsync();

        /// <summary>
        /// Get item by its Guid
        /// </summary>
        /// <returns>A item T</returns>
        public Task<T?> GetByIdAsync(Guid id);
    }
}
