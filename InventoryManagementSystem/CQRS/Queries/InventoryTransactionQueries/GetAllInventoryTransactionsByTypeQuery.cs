namespace InventoryManagementSystem.CQRS.Queries.InventoryTransactionQueries
{
    public class GetAllInventoryTransactionsByTypeQuery : IRequest<IEnumerable<InventoryTransactionViewModel>>
    {
        public TransactionType Type { get; set; }
    }


    public class GetAllInventoryTransactionsByTypeQueryHandler : IRequestHandler<GetAllInventoryTransactionsByTypeQuery, IEnumerable<InventoryTransactionViewModel>>
    {
        private IInventoryTransactionRepository _repository;
        public GetAllInventoryTransactionsByTypeQueryHandler(IInventoryTransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<InventoryTransactionViewModel>> Handle(GetAllInventoryTransactionsByTypeQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllTransactionByType(request.Type);

            List<InventoryTransactionViewModel> response = new List<InventoryTransactionViewModel>();
            foreach (var transaction in data)
            {
                response.Add(new InventoryTransactionViewModel(transaction));
            }
            return response;
        }
    }

}
