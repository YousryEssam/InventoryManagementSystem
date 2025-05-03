namespace InventoryManagementSystem.DTOs.WarehouseProduct
{
    public class NewWarehouseProductDTO
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int WarehouseId { get; set; }
        
        [Range(0 , int.MaxValue, ErrorMessage = "Quantity must be more than or equal to 0.")]
        public int Quantity { get; set; }
    }
}
