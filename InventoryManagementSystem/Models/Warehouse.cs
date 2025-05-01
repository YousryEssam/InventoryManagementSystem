namespace InventoryManagementSystem.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        public string Name { get; set; }


        [Required]
        [StringLength(256, ErrorMessage = "Location cannot exceed 256 characters.")]
        public string Location { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total Product Quantity must be at least 0.")]
        public int TotalProductQuantity { get; set; } = 0;


        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}
