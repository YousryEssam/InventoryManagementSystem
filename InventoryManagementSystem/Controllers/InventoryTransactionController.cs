using InventoryManagementSystem.CQRS.Queries.InventoryTransactionQueries;
using InventoryManagementSystem.ViewModels.InventoryTransactionViewModels;
using InventoryManagementSystem.ViewModels.WarehouseViewModels;

namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryTransactionController : BaseAPIController
    {
        public InventoryTransactionController(IMediator mediator) : base(mediator) { }


    }
}
