namespace InventoryManagementSystem.DTOs.InventoryTransactionDTOs
{
    public class NewInventoryTransactionDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }


        [Required]
        public TransactionType Type { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0.")]
        public int Quantity { get; set; }


        [StringLength(256, ErrorMessage = "Notes cannot exceed 256 characters.")]
        public string? Notes { get; set; }

        public int? SourceWarehouseId { get; set; }

        public int? DestinationWarehouseId { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public NewInventoryTransactionDTO()
        {

        }

        public InventoryTransaction GetTransaction()
        {
            return new InventoryTransaction()
            {
                UserId = UserId,
                ProductId = ProductId,
                Type = Type,
                Quantity = Quantity,
                Notes = Notes,
                SourceWarehouseId = SourceWarehouseId,
                DestinationWarehouseId = DestinationWarehouseId,
                TransactionDate = TransactionDate
            };
        }
    }
}
