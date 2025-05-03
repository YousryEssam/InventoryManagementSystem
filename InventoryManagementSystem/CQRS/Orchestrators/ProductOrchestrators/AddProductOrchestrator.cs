namespace InventoryManagementSystem.CQRS.Orchestrators.ProductOrchestrators
{
    public class AddProductOrchestrator : IRequest<bool>
    {
        public NewProductDTO NewProductDTO { get; set; } 
    }

    public class AddProductOrchestratorHandler : IRequestHandler<AddProductOrchestrator, bool>
    {
        private IMediator _mediator;
        private IProductRepository _repository;
        public AddProductOrchestratorHandler(IMediator mediator)
        {
            _mediator = mediator;
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

                if(step2 <= 0)
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

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                 transaction.Rollback();
                return false;
            }
        }
    }

}
