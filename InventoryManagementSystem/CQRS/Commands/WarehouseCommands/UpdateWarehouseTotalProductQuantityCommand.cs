namespace InventoryManagementSystem.CQRS.Commands.WarehouseCommands
{
    public class UpdateWarehouseTotalProductQuantityCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int TotalProductQuantity { get; set; }
    }

    public class UpdateWarehouseTotalProductQuantityCommandHandler : IRequestHandler<UpdateWarehouseTotalProductQuantityCommand, bool>
    {
        private IWarehouseRepository _repository;
        public UpdateWarehouseTotalProductQuantityCommandHandler(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateWarehouseTotalProductQuantityCommand request, CancellationToken cancellationToken)
        {
            var isUpdated = await _repository.UpdateWarehouseTotalProductQuantity(request.Id, request.TotalProductQuantity);
            if (isUpdated)
            {
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
