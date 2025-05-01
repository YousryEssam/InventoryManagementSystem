namespace InventoryManagementSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 128 characters.")]
        public string Name { get; set; }


        [StringLength(1024, ErrorMessage = "Description cannot exceed 1024 characters.")]
        public string? Description { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be at least 0.01")]
        public decimal Price { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0.")]
        public int Quantity { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Low Stock Threshold must be at least 1.")]
        public int LowStockThreshold { get; set; }


        public bool IsDeleted { get; set; } = false;


        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
