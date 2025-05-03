namespace InventoryManagementSystem.CQRS.Commands.WarehouseCommands
{
    public class UpdateWarehouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateWarehouseDTO UpdateWarehouseDTO { get; set; }
    }

    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, bool>
    {
        private IWarehouseRepository _warehouseRepository;
        public UpdateWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<bool> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(request.Id);
            if (warehouse == null)
            {
                return false;
            }
            if (request.UpdateWarehouseDTO.Name != null)
            {
                warehouse.Name = request.UpdateWarehouseDTO.Name;
            }
            if (request.UpdateWarehouseDTO.Location != null)
            {
                warehouse.Location = request.UpdateWarehouseDTO.Location;
            }
            await _warehouseRepository.SaveChangesAsync();
            return true;
        }
    }
}
