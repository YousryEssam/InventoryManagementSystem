namespace InventoryManagementSystem.Repositories.Interfaces
{
    public interface IWarehouseRepository : IGenericRepository<Warehouse>
    {
        Task<bool> SoftDeleteByIdAsync(int id);
    }
}
