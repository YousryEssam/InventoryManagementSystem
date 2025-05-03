namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseProductController : BaseAPIController
    {
        public WarehouseProductController(IMediator mediator) : base(mediator) { }

    }
}
