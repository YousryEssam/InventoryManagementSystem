namespace InventoryManagementSystem.Repositories.Implementations
{
    public class InventoryTransactionRepository : GenericRepository<InventoryTransaction>, IInventoryTransactionRepository
    {
        public InventoryTransactionRepository(InventoryManagementDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<InventoryTransaction>> GetAllTransaction()
        {
            return await _context.InventoryTransactions
                .Include(it => it.User)
                .Include(it => it.Product)
                .OrderByDescending(it => it.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryTransaction>> GetAllTransactionByProductId(int id)
        {
            return await _context.InventoryTransactions
                .Include(it => it.User)
                .Include(it => it.Product)
                .Where(it => it.ProductId == id)
                .OrderByDescending(it => it.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryTransaction>> GetAllTransactionByType(TransactionType type)
        {
            return await _context.InventoryTransactions
                 .Include(it => it.User)
                 .Include(it => it.Product)
                 .Where(it => it.Type == type)
                 .OrderByDescending(it => it.TransactionDate)
                 .ToListAsync();
        }

        public async Task<IEnumerable<InventoryTransaction>> GetAllTransactionInDateRange(DateTime start, DateTime end)
        {
            return await _context.InventoryTransactions
                .Include(it => it.User)
                .Include(it => it.Product)
                .Where(it => it.TransactionDate >= start && it.TransactionDate <= end)
                .OrderByDescending(it => it.TransactionDate)
                .ToListAsync();
        }
    }
}
