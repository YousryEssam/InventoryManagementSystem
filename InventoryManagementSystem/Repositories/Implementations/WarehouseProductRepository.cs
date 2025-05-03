namespace InventoryManagementSystem.Repositories.Implementations
{
    public class WarehouseProductRepository : GenericRepository<WarehouseProduct> , IWarehouseProductRepository
    {
        public WarehouseProductRepository(InventoryManagementDbContext context) : base(context) 
        {
        
        }

        public async Task<WarehouseProduct> GetByForeignKeysAsync(int productId, int warehouseId)
        {
            return await _context.WarehouseProducts
                .Where(wp => wp.WarehouseId == warehouseId && wp.ProductId == productId)
                .Include(wp => wp.Product)
                .Include(wp => wp.Warehouse)
                .FirstOrDefaultAsync();
        }
    }
}
