namespace InventoryManagementSystem.CQRS.Commands.WarehouseCommands
{
    public class AddWarehouseCommand : IRequest<bool>
    {
        public NewWarehouseDTO NewWarehouseDTO { get; set; }
    }

    public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommand, bool>
    {
        private IWarehouseRepository _warehouseRepository;
        public AddWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<bool> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _warehouseRepository.AddAsync(request.NewWarehouseDTO.GetWarehouse());
                await _warehouseRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
