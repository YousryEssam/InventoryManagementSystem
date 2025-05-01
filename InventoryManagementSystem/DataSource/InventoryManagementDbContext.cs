namespace InventoryManagementSystem.DataSource
{
    public class InventoryManagementDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public InventoryManagementDbContext() 
        {

        }
        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options) : base(options)
        {

        }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
    }
}
