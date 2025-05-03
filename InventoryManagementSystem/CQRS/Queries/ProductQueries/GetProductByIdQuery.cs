
namespace InventoryManagementSystem.CQRS.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private IProductRepository _repository;
        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null) {
                return null;
            }
            ProductViewModel productViewModel = new ProductViewModel(product);
            return productViewModel;
        }
    }

}
