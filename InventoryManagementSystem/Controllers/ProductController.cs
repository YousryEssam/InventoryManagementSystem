namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseAPIController
    {
        public ProductController(IMediator mediator) : base(mediator) { }

        [HttpGet("id:{int}")]
        public async Task<ResponseViewModel<ProductViewModel>> GetById(int id)
        {
            var productViewModel = await _mediator.Send(new GetProductByIdQuery { Id = id });

            if (productViewModel is null)
            {
                return await UnsuccessfulRequest<ProductViewModel>(ErrorCode.InvalidID, "Invalid ID.");
            }

            return await SuccessfulRequest(productViewModel, "Successful Request");
        }
        [HttpGet("All")]
        public async Task<ResponseViewModel<IEnumerable<ProductViewModel>>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return await SuccessfulRequest(products, "Successful Request");
        }

        //[HttpPost("Add")]

        //[HttpPut("{id:int}")]

        //[HttpDelete("{id:int}")]

    }
}
