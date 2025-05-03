

namespace InventoryManagementSystem.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(InventoryManagementDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetAllLowStockThresholdAsync()
        {
            return await _context.Products
                .Where(p => p.LowStockThreshold >= p.Quantity)
                .ToListAsync();
        }

        public async Task<bool> SoftDeleteByIdAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                return true;
            }
            return false;
        }
    }
}
