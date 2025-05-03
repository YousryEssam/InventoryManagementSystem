namespace InventoryManagementSystem.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int LowStockThreshold { get; set; }


        //public bool IsDeleted { get; set; } = false;

        public DateTime? UpdatedAt { get; set; }

        public ProductViewModel() { }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;
            UpdatedAt = product.UpdatedAt;
            LowStockThreshold = product.LowStockThreshold;
        }
    }
}
