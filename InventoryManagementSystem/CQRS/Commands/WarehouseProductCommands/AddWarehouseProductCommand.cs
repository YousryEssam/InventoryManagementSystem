namespace InventoryManagementSystem.CQRS.Commands.WarehouseProductCommands
{
    public class AddWarehouseProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddWarehouseProductCommandHandler : IRequestHandler<AddWarehouseProductCommand, bool>
    {
        private IWarehouseProductRepository _repository;
        public AddWarehouseProductCommandHandler(IWarehouseProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(AddWarehouseProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var warehouseProduct = await _repository.GetByForeignKeysAsync(request.ProductId, request.WarehouseId);
                if (warehouseProduct == null)
                {
                    var newWarehouseProduct = new WarehouseProduct
                    {
                        ProductId = request.ProductId,
                        WarehouseId = request.WarehouseId,
                        Quantity = request.Quantity
                    };
                    await _repository.AddAsync(newWarehouseProduct);
                    await _repository.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
