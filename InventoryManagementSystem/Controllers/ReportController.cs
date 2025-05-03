using InventoryManagementSystem.CQRS.Queries.InventoryTransactionQueries;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    public class ReportController: BaseAPIController
    {
        public ReportController(IMediator mediator) : base(mediator) { }


        [HttpGet("All")]
        public async Task<ResponseViewModel<IEnumerable<InventoryTransactionViewModel>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllInventoryTransactionsQuery());
            return await SuccessfulRequest(response, "Successful Request");
        }

        [HttpGet("All/Type/{type:int}")]
        public async Task<ResponseViewModel<IEnumerable<InventoryTransactionViewModel>>> GetAllByType(TransactionType type)
        {
            var response = await _mediator.Send(new GetAllInventoryTransactionsByTypeQuery() { Type = type });
            return await SuccessfulRequest(response, "Successful Request");
        }

        [HttpGet("All/ByDateRange")]
        public async Task<ResponseViewModel<IEnumerable<InventoryTransactionViewModel>>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var response = await _mediator.Send(new GetAllInventoryTransactionsQuery());
            return await SuccessfulRequest(response, "Successful Request");
        }
    }
}