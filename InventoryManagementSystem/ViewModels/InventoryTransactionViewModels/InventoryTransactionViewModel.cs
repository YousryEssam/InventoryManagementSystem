namespace InventoryManagementSystem.ViewModels.InventoryTransactionViewModels
{
    public class InventoryTransactionViewModel
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }


        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }


        public TransactionType Type { get; set; }

        public int Quantity { get; set; }

        public string? Notes { get; set; }


        public int? SourceWarehouseId { get; set; }

        public int? DestinationWarehouseId { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public InventoryTransactionViewModel() { }
        public InventoryTransactionViewModel(InventoryTransaction transaction)
        {
            UserId = transaction.UserId;
            UserFirstName = transaction.User.FirstName;
            UserLastName = transaction.User.LastName;

            ProductId = transaction.ProductId;
            ProductName = transaction.Product.Name;
            ProductDescription = transaction.Product.Description;

            Type = transaction.Type;
            Quantity = transaction.Quantity;
            Notes = transaction.Notes;
            SourceWarehouseId = transaction.SourceWarehouseId;
            DestinationWarehouseId = transaction.DestinationWarehouseId;
            TransactionDate = transaction.TransactionDate;
        }
    }
}
