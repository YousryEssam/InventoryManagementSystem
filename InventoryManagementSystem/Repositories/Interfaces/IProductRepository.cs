namespace InventoryManagementSystem.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> SoftDeleteByIdAsync(int id);
    }
}
