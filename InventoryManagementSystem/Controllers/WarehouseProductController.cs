namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseProductController : BaseAPIController
    {
        public WarehouseProductController(IMediator mediator) : base(mediator) { }

        [HttpGet("productId/{productId:int}/warehouseId/{warehouseId:int}")]
        public async Task<ResponseViewModel<WarehouseProductViewModel>> GetWarehouseProductByIds(int productId, int warehouseId)
        {
            var warehouseProductViewModel = await _mediator.Send(new GetWarehouseProductQuery() { ProductId = productId, WarehouseId = warehouseId });
            if (warehouseProductViewModel == null)
            {
                return await UnsuccessfulRequest<WarehouseProductViewModel>(ErrorCode.InvalidID, "Invalid IDs.");
            }

            return await SuccessfulRequest(warehouseProductViewModel, "Successful Request");
        }

        [HttpPost("Add")]
        public async Task<ResponseViewModel<bool>> AddNew(NewWarehouseProductDTO warehouseProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.ValidationError, "Validation Error");
            }

            bool successfulAdd = await _mediator.Send(new AddWarehouseProductCommand()
            {
                ProductId = warehouseProductDTO.ProductId,
                WarehouseId = warehouseProductDTO.WarehouseId,
                Quantity = warehouseProductDTO.Quantity
            });

            if (!successfulAdd)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.AlreadyCreated, "Unsuccessful create because Already Created.");
            }

            return await SuccessfulRequest(true, "Successful creation.");
        }

        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel<bool>> Update(int id, UpdateWarehouseProductDTO updateWarehouseProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.ValidationError, "Validation Error");
            }

            ErrorCode hasError = await _mediator.Send(new UpdateWarehouseProductCommand()
            {
                ProductId = updateWarehouseProductDTO.ProductId,
                WarehouseId = updateWarehouseProductDTO.WarehouseId,
                Quantity = updateWarehouseProductDTO.Quantity
            });

            if (hasError != ErrorCode.NoError)
            {
                return await UnsuccessfulRequest<bool>(hasError, "Unsuccessful.");
            }

            return await SuccessfulRequest(true, "Successful update.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            bool isDeletedSuccessfully = await _mediator.Send(new DeleteWarehouseProductCommand() { Id = id });
            if (!isDeletedSuccessfully)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.InvalidID, "Invalid ID.");
            }

            return await SuccessfulRequest(true, "Deleted successfully");
        }
    }
}
