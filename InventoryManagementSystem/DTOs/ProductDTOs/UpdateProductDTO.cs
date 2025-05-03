namespace InventoryManagementSystem.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {

        [Required]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 128 characters.")]
        public string? Name { get; set; }

        [StringLength(1024, ErrorMessage = "Description cannot exceed 1024 characters.")]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be at least 0.01")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Low Stock Threshold must be at least 1.")]
        public int LowStockThreshold { get; set; }

        public UpdateProductDTO()
        {

        }

        public UpdateProductDTO(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            LowStockThreshold = product.LowStockThreshold;
        }
        public void UpdateEntity(Product product)
        {
            if (Name != null)
            {
                product.Name = Name;
            }
            if (Description != null)
            {
                product.Description = Description;
            }
            if (Price != 0)
            {
                product.Price = Price;
            }

            if(LowStockThreshold != 0)
            {
                product.LowStockThreshold = LowStockThreshold;
            }
            product.UpdatedAt = DateTime.Now;
        }
    }
}
