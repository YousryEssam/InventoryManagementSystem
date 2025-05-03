namespace InventoryManagementSystem.CQRS.Queries.InventoryTransactionQueries
{
    public class GetAllInventoryTransactionsByProductIdQuery : IRequest<IEnumerable<InventoryTransactionViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetAllInventoryTransactionsByProductIdQueryHandler :
        IRequestHandler<GetAllInventoryTransactionsByProductIdQuery,IEnumerable<InventoryTransactionViewModel>>
    {
        IInventoryTransactionRepository _repository;
        public GetAllInventoryTransactionsByProductIdQueryHandler(IInventoryTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InventoryTransactionViewModel>> Handle(GetAllInventoryTransactionsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllTransactionByProductId(request.Id);

            List<InventoryTransactionViewModel> response = new List<InventoryTransactionViewModel>();
            foreach (var transaction in data)
            {
                response.Add(new InventoryTransactionViewModel(transaction));
            }
            return response;
        }
    }
}
