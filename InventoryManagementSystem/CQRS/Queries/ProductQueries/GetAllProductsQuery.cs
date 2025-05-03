namespace InventoryManagementSystem.CQRS.Queries.ProductQueries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {

    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductViewModel>>
    {
        private IProductRepository _repository;
        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            List<ProductViewModel> response = new List<ProductViewModel>();
            foreach (var item in products)
            {
                response.Add(new ProductViewModel(item)); 
            }
            return response;
        }
    }
}
