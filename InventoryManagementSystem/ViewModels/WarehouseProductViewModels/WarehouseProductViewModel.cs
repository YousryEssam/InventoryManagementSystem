namespace InventoryManagementSystem.ViewModels.WarehouseProductViewModels
{
    public class WarehouseProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }

        public int QuantityInWarehouse { get; set; }

        public WarehouseProductViewModel() { }
        public WarehouseProductViewModel(Product product, Warehouse warehouse, int quantityInWarehouse)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            ProductDescription = product.Description;
            ProductPrice = product.Price;

            WarehouseId = warehouse.Id;
            WarehouseName = warehouse.Name;
            WarehouseLocation = warehouse.Location;

            QuantityInWarehouse = quantityInWarehouse;
        }

    }
}
