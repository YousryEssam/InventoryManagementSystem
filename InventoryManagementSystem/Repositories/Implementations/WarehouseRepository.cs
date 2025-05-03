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

        public async Task<bool> UpdateWarehouseTotalProductQuantity(int id, int Quantity)
        {
            var warehouse = await _context.Warehouses
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            if (warehouse == null)
            {
                return false;
            }
            warehouse.TotalProductQuantity += Quantity;
            return true;
        }
    }
}
