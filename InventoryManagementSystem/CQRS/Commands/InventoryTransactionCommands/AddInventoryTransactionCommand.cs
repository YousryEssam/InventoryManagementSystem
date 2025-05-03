namespace InventoryManagementSystem.CQRS.Commands.InventoryTransactionCommands
{
    public class AddInventoryTransactionCommand : IRequest<bool>
    {
        public NewInventoryTransactionDTO transactionDTO {  get; set; }
    }

    public class AddInventoryTransactionCommandHandler : IRequestHandler<AddInventoryTransactionCommand, bool>
    {
        private IInventoryTransactionRepository _repository;

        public AddInventoryTransactionCommandHandler(IInventoryTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AddInventoryTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(request.transactionDTO.GetTransaction());
                await _repository.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
