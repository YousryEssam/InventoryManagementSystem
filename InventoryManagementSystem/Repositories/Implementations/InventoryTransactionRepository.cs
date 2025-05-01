namespace InventoryManagementSystem.Repositories.Implementations
{
    public class InventoryTransactionRepository : GenericRepository<InventoryTransaction> , IInventoryTransactionRepository
    {
        public InventoryTransactionRepository(InventoryManagementDbContext context) : base(context) 
        {

        }

    }
}
