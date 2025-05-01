namespace InventoryManagementSystem.Repositories.Implementations
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser> , IApplicationUserRepository
    {
        public ApplicationUserRepository(InventoryManagementDbContext context) : base(context)
        {

        }
    }
}