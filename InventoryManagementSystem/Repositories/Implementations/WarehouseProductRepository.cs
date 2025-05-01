namespace InventoryManagementSystem.Repositories.Implementations
{
    public class WarehouseProductRepository : GenericRepository<WarehouseProduct> , IWarehouseProductRepository
    {
        public WarehouseProductRepository(InventoryManagementDbContext context) : base(context) 
        {
        
        }

    }
}
