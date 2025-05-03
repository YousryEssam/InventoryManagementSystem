namespace InventoryManagementSystem.CQRS.Commands.WarehouseCommands
{
    public class DeleteWarehouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, bool>
    {
        private IWarehouseRepository _warehouseRepository;
        public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _warehouseRepository.SoftDeleteByIdAsync(request.Id);
            if (isDeleted)
            {
                await _warehouseRepository.SaveChangesAsync();
            }
            return isDeleted;
        }
    }
}
