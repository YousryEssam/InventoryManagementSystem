namespace InventoryManagementSystem.CQRS.Commands.WarehouseProductCommands
{
    public class UpdateWarehouseProductCommand : IRequest<ErrorCode>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateWarehouseProductCommandHandler : IRequestHandler<UpdateWarehouseProductCommand, ErrorCode>
    {
        private IWarehouseProductRepository _repository;
        public UpdateWarehouseProductCommandHandler(IWarehouseProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorCode> Handle(UpdateWarehouseProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var warehouseProduct = await _repository.GetByForeignKeysAsync(request.ProductId, request.WarehouseId);
                if (warehouseProduct == null)
                {
                    return ErrorCode.DoesNotExistEntity;
                }
                if (warehouseProduct.Quantity + request.Quantity < 0)
                {
                    return ErrorCode.StockLowerThanRequest;
                }
                warehouseProduct.Quantity += request.Quantity;
                _repository.Update(warehouseProduct);
                await _repository.SaveChangesAsync();
                return ErrorCode.NoError;
            }
            catch (Exception ex)
            {
                return ErrorCode.UnExceptedError;
            }
        }
    }
}
