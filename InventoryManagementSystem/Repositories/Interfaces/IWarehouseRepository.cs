namespace InventoryManagementSystem.Repositories.Interfaces
{
    public interface IWarehouseRepository : IGenericRepository<Warehouse>
    {
        Task<bool> SoftDeleteByIdAsync(int id);
        Task<bool> UpdateWarehouseTotalProductQuantity(int id, int Quantity);
    }
}
