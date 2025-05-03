namespace InventoryManagementSystem.CQRS.Orchestrators.ProductOrchestrators
{
    public class AddProductOrchestrator : IRequest<bool>
    {
        public int UserId { get; set; }
        public NewProductDTO NewProductDTO { get; set; }
    }

    public class AddProductOrchestratorHandler : IRequestHandler<AddProductOrchestrator, bool>
    {
        private IMediator _mediator;
        private IProductRepository _repository;

        public AddProductOrchestratorHandler(IMediator mediator, IProductRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<bool> Handle(AddProductOrchestrator request, CancellationToken cancellationToken)
        {
            IDbContextTransaction transaction = null;

            try
            {
                transaction = await _repository.BeginTransactionAsync();

                // cheek warehouse and add Quantity
                var step1 = await _mediator.Send(new UpdateWarehouseTotalProductQuantityCommand()
                {
                    Id = request.NewProductDTO.WarehouseId,
                    TotalProductQuantity = request.NewProductDTO.Quantity,
                });

                // create product 
                var step2 = await _mediator.Send(new AddProductCommand()
                {
                    NewProductDTO = request.NewProductDTO,
                });

                if (step2 <= 0)
                {
                    transaction.Rollback();
                    return false;
                }


                // update warehouse product 
                var step3 = await _mediator.Send(new AddWarehouseProductCommand()
                {
                    ProductId = step2,
                    WarehouseId = request.NewProductDTO.WarehouseId,
                    Quantity = request.NewProductDTO.Quantity,
                });



                // add new inventory transaction 
                var TransactionDTO = new NewInventoryTransactionDTO()
                {
                    ProductId = step2,
                    Notes = "",
                    Quantity = request.NewProductDTO.Quantity,
                    Type = TransactionType.InitialStock,
                    UserId = request.UserId,
                    DestinationWarehouseId = request.NewProductDTO.WarehouseId,
                    TransactionDate = DateTime.Now,
                };
                var step4 = await _mediator.Send(new AddInventoryTransactionCommand()
                {
                    transactionDTO = TransactionDTO,
                });
                if (step1 && step3 && step4)
                {
                    transaction.Commit();
                    return true;
                }
                transaction.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}