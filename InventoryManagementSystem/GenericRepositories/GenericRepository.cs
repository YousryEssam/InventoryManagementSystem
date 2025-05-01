namespace InventoryManagementSystem.GenericRepositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbSet<TModel> _dbSet;
        protected readonly InventoryManagementDbContext _context;
        public GenericRepository(InventoryManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public async Task AddAsync(TModel entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TModel entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TModel?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void UpdateAsync(TModel entity)
        {
            _dbSet.Update(entity);
        }
    }
}
