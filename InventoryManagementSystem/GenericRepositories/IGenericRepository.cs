namespace InventoryManagementSystem.GenericRepositories
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task AddAsync(TModel entity);
        void Delete(TModel entity);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel?> GetByIdAsync(int id);
        void UpdateAsync(TModel entity);
    }
}
