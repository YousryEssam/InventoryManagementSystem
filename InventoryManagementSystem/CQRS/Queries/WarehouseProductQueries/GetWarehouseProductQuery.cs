namespace InventoryManagementSystem.CQRS.Queries.WarehouseProductQueries
{
    public class GetWarehouseProductQuery : IRequest<WarehouseProductViewModel>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
    }
    public class GetWarehouseProductQueryHandler : IRequestHandler<GetWarehouseProductQuery, WarehouseProductViewModel>
    {
        IWarehouseProductRepository _repository;
        public GetWarehouseProductQueryHandler(IWarehouseProductRepository repository)
        {
            _repository = repository;

        }

        public async Task<WarehouseProductViewModel> Handle(GetWarehouseProductQuery request, CancellationToken cancellationToken)
        {
            var warehouseProduct = await _repository.GetByForeignKeysAsync(request.ProductId, request.WarehouseId);
            if (warehouseProduct == null)
            {
                return null;
            }
            return new WarehouseProductViewModel(warehouseProduct.Product, warehouseProduct.Warehouse, warehouseProduct.Quantity);
        }
    }
}
