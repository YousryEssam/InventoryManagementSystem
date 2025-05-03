namespace InventoryManagementSystem.CQRS.Queries.InventoryTransactionQueries
{
    public class GetAllInventoryTransactionsInDateRangeQuery : IRequest<IEnumerable<InventoryTransactionViewModel>>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class GetAllInventoryTransactionsInDateRangeQueryHandler : IRequestHandler<GetAllInventoryTransactionsInDateRangeQuery, IEnumerable<InventoryTransactionViewModel>>
    {
        private IInventoryTransactionRepository _repository;
        public GetAllInventoryTransactionsInDateRangeQueryHandler(IInventoryTransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<InventoryTransactionViewModel>> Handle(GetAllInventoryTransactionsInDateRangeQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllTransactionInDateRange(request.Start, request.End);

            List<InventoryTransactionViewModel> response = new List<InventoryTransactionViewModel>();
            foreach (var transaction in data)
            {
                response.Add(new InventoryTransactionViewModel(transaction));
            }
            return response;
        }
    }
}
