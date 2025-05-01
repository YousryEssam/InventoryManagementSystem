namespace InventoryManagementSystem.Models
{
    public class WarehouseProduct
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        [Required]
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0.")]
        public int Quantity { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
