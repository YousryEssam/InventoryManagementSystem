namespace InventoryManagementSystem.CQRS.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateProductDTO updateProductDTO {  get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null) 
            {
                return false;
            }
            request.updateProductDTO.UpdateEntity(product);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
