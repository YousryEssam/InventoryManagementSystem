
namespace InventoryManagementSystem.CQRS.Commands.ProductCommands
{
    public class AddProductCommand : IRequest<int>
    {
        public NewProductDTO NewProductDTO { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private IProductRepository _repository;
        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = request.NewProductDTO.GetProduct();
                await _repository.AddAsync(product);
                await _repository.SaveChangesAsync();
                return product.Id;
            }
            catch
            {
                return -1;
            }
           
        }
    }
}
