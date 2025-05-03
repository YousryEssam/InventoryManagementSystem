using InventoryManagementSystem.ViewModels.WarehouseViewModels;

namespace InventoryManagementSystem.CQRS.Queries.WarehouseQueries
{
    public class GetWarehouseByIdQuery : IRequest<WarehouseViewModel>
    {
        public int Id { get; set; }
    }

    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseViewModel>
    {
        private IWarehouseRepository _repository;
        public GetWarehouseByIdQueryHandler(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarehouseViewModel> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _repository.GetByIdAsync(request.Id);
            if (warehouse == null) {
                return null;
            }
            return new WarehouseViewModel(warehouse);
        }
    }
}
