
namespace InventoryManagementSystem.CQRS.Queries.WarehouseQueries
{
    public class GetAllWarehousesQuery : IRequest<IEnumerable<WarehouseViewModel>>
    {

    }

    public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, IEnumerable<WarehouseViewModel>>
    {
        private IWarehouseRepository _repository;
        public GetAllWarehousesQueryHandler(IWarehouseRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<WarehouseViewModel>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _repository.GetAllAsync();
            List<WarehouseViewModel> response = new List<WarehouseViewModel>();
            foreach (var item in warehouses) {
                response.Add(new WarehouseViewModel(item));
            }
            return response;
        }
    }
}
