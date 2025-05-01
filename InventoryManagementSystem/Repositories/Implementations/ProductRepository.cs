namespace InventoryManagementSystem.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(InventoryManagementDbContext context) : base(context) { }

    }
}
