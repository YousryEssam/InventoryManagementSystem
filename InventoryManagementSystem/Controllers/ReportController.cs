namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    public class ReportController: BaseAPIController
    {
        public ReportController(IMediator mediator) : base(mediator) { }
    }
}