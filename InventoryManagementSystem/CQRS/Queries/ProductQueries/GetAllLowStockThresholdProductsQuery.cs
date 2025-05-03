
namespace InventoryManagementSystem.CQRS.Queries.ProductQueries
{
    public class GetAllLowStockThresholdProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {

    }

    public class GetAllLowStockThresholdProductsQueryHandler :
        IRequestHandler<GetAllLowStockThresholdProductsQuery, IEnumerable<ProductViewModel>>
    {
        private IProductRepository _repository;
        public GetAllLowStockThresholdProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllLowStockThresholdProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllLowStockThresholdAsync();
            List<ProductViewModel> response = new List<ProductViewModel>();
            foreach (var item in products)
            {
                response.Add(new ProductViewModel(item));
            }
            return response;
        }
    }
}
