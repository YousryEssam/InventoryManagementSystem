namespace InventoryManagementSystem.Repositories.Interfaces
{
    public interface IInventoryTransactionRepository : IGenericRepository<InventoryTransaction>
    {
        Task<IEnumerable<InventoryTransaction>> GetAllTransaction();
        Task<IEnumerable<InventoryTransaction>> GetAllTransactionByType(TransactionType type);
        Task<IEnumerable<InventoryTransaction>> GetAllTransactionInDateRange(DateTime start, DateTime end);
    }
}
