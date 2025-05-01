namespace InventoryManagementSystem.Repositories.Implementations
{
    public class NotificationRepository : GenericRepository<Notification> , INotificationRepository
    {
        public NotificationRepository(InventoryManagementDbContext context) : base(context) 
        {

        }
    }
}
