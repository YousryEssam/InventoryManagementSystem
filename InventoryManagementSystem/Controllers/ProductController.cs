namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseAPIController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator)
        {
            _userManager = userManager;
        }

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

        [HttpPost("Add")]
        public async Task<ResponseViewModel<bool>> AddNew(NewProductDTO newProduct)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.ValidationError, "Validation Error");
            }

            var user = await _userManager.GetUserAsync(User);
            int userId = user.Id;


            bool successfulAdd = await _mediator.Send(new AddProductOrchestrator() { NewProductDTO = newProduct ,UserId = userId });

            if (!successfulAdd)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.UnExceptedError, "Unsuccessful create new Product.");
            }
            return await SuccessfulRequest(true, "Successful create new Product.");
        }

        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel<bool>> Update(int id, UpdateProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.ValidationError, "Validation Error");
            }

            bool successfulUpdated = await _mediator.Send(new UpdateProductCommand() { Id = id, updateProductDTO = productDTO });
            if (!successfulUpdated)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.UnExceptedError, "Unsuccessful Update product.");
            }

            return await SuccessfulRequest(true, "Successful Update product.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            bool isDeletedSuccessfully = await _mediator.Send(new DeleteProductCommand() { Id = id });
            
            if (!isDeletedSuccessfully)
            {
                return await UnsuccessfulRequest<bool>(ErrorCode.InvalidID, "Invalid ID.");
            }

            return await SuccessfulRequest(true, "Deleted successfully");
        }

    }
}
