namespace InventoryManagementSystem.CQRS.Commands.WarehouseProductCommands
{
    public class DeleteWarehouseProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
    public class DeleteWarehouseProductCommandHandler : IRequestHandler<DeleteWarehouseProductCommand , bool>
    {
        private IWarehouseProductRepository _repository;
        public DeleteWarehouseProductCommandHandler(IWarehouseProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteWarehouseProductCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _repository.DeleteById(request.Id);

            if (isDeleted)
            {
                await _repository.SaveChangesAsync();
            }

            return isDeleted;
        }
    }
}
