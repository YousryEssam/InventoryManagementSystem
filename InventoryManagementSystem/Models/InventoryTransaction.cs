namespace InventoryManagementSystem.Models
{
    public class InventoryTransaction
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        [Required]
        public TransactionType Type { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0.")]
        public int Quantity { get; set; }


        [StringLength(256, ErrorMessage = "Notes cannot exceed 256 characters.")]
        public string? Notes { get; set; }


        [ForeignKey("SourceWarehouse")]
        public int? SourceWarehouseId { get; set; }


        [ForeignKey("DestinationWarehouse")]
        public int? DestinationWarehouseId { get; set; }


        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Warehouse? SourceWarehouse { get; set; }
        public virtual Warehouse? DestinationWarehouse { get; set; }
    }
}
