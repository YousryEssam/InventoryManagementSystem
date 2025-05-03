namespace InventoryManagementSystem.CQRS.Commands.WarehouseCommands
{
    public class DeleteWarehouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, bool>
    {
        private IWarehouseRepository _repository;
        public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _repository = warehouseRepository;
        }
        public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _repository.SoftDeleteByIdAsync(request.Id);
            if (isDeleted)
            {
                await _repository.SaveChangesAsync();
            }
            return isDeleted;
        }
    }
}
