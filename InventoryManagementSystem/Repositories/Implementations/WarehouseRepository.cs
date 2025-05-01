namespace InventoryManagementSystem.Repositories.Implementations
{
    public class WarehouseRepository :GenericRepository<Warehouse> , IWarehouseRepository
    {
        public WarehouseRepository(InventoryManagementDbContext context) : base(context) 
        {

        }
    }
}
