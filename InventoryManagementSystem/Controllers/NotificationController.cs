namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : BaseAPIController
    {
        public NotificationController(IMediator mediator) : base(mediator) { }

    }
}
