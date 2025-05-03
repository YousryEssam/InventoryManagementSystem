using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        protected IMediator _mediator;
        public BaseAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ResponseViewModel<T>> UnsuccessfulRequest<T>(ErrorCode errorCode, string msg)
        {
            return await Task.FromResult(ResponseViewModel<T>.UnsuccessfulResponse(errorCode, msg));
        }

        protected async Task<ResponseViewModel<T>> SuccessfulRequest<T>(T data, string msg = "")
        {
            return await Task.FromResult(ResponseViewModel<T>.SuccessfulResponse(data, msg));
        }
    }
}
