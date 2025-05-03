using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : BaseAPIController
    {
        public WarehouseController(IMediator mediator) : base(mediator) { }

        [HttpGet("id:{int}")]
        public async Task<ResponseViewModel<WarehouseViewModel>> GetById(int id)
        {
            var warehouseViewModel = await _mediator.Send(new GetWarehouseByIdQuery { Id = id });

            if (warehouseViewModel is null)
            {
                return await UnsuccessfulRequest<WarehouseViewModel>(ErrorCode.InvalidID, "Invalid ID.");
            }
            return await SuccessfulRequest(warehouseViewModel, "Successful Request");
        }

        [HttpGet("All")]
        public async Task<ResponseViewModel<IEnumerable<WarehouseViewModel>>> GetAll()
        {
            var warehouses = await _mediator.Send(new GetAllWarehousesQuery());
            return await SuccessfulRequest(warehouses, "Successful Request");
        }

        [HttpPost("Add")]
        public async Task<ResponseViewModel<bool>> AddNew(NewWarehouseDTO warehouseDTO)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.ValidationError, "Validation Error");
            }
            bool successfulAdd = await _mediator.Send(new AddWarehouseCommand() { NewWarehouseDTO = warehouseDTO });
            if (!successfulAdd)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.UnExceptedError, "Unsuccessful create new warehouse.");
            }
            return await SuccessfulRequest(true, "Successful create new warehouse.");
        }

        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel<bool>> Update(int id , UpdateWarehouseDTO updateWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.ValidationError, "Validation Error");
            }

            bool successfulUpdated = await _mediator.Send(new UpdateWarehouseCommand() { Id = id , UpdateWarehouseDTO = updateWarehouse });
            if (!successfulUpdated)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.UnExceptedError, "Unsuccessful Update warehouse.");
            }

            return await SuccessfulRequest(true, "Successful Update warehouse.");

        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            bool isDeletedSuccessfully = await _mediator.Send(new DeleteWarehouseCommand() { Id = id });
            if (!isDeletedSuccessfully)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.InvalidID, "Invalid ID.");
            }

            return await SuccessfulRequest(true, "Deleted successfully");
        }
    }
}
