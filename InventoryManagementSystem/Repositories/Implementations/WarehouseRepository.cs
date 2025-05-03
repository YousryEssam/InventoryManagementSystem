
namespace InventoryManagementSystem.Repositories.Implementations
{
    public class WarehouseRepository :GenericRepository<Warehouse> , IWarehouseRepository
    {
        public WarehouseRepository(InventoryManagementDbContext context) : base(context) 
        {

        }

        public async Task<bool> SoftDeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) {
                return false;
            }
            entity.IsDeleted = true;
            return true;
        }
    }
}
