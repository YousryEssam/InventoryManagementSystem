namespace InventoryManagementSystem.CQRS.Commands.ProductCommands
{
    public class DeleteProductCommand :IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private IProductRepository _repository;
        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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
