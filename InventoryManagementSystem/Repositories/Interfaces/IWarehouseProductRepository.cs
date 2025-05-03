namespace InventoryManagementSystem.Repositories.Interfaces
{
    public interface IWarehouseProductRepository : IGenericRepository<WarehouseProduct>
    {
        Task<WarehouseProduct> GetByForeignKeysAsync(int productId, int warehouseId);
    }
}
