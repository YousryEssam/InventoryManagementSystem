
namespace InventoryManagementSystem.CQRS.Queries.InventoryTransactionQueries
{
    public class GetAllInventoryTransactionsQuery : IRequest<IEnumerable<InventoryTransactionViewModel>>
    {

    }

    public class GetAllInventoryTransactionsQueryHandler : IRequestHandler<GetAllInventoryTransactionsQuery, IEnumerable<InventoryTransactionViewModel>>
    {
        private IInventoryTransactionRepository _repository;
        public GetAllInventoryTransactionsQueryHandler(IInventoryTransactionRepository repository )
        {
            _repository = repository;
        }
        public async Task<IEnumerable<InventoryTransactionViewModel>> Handle(GetAllInventoryTransactionsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllTransaction();

            List<InventoryTransactionViewModel> response = new List<InventoryTransactionViewModel>();
            foreach (var transaction in data)
            {
                response.Add(new InventoryTransactionViewModel(transaction));
            }
            return response;
        }
    }
}
