namespace InventoryManagementSystem.ViewModels.WarehouseViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [StringLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        public string Name { get; set; }

        [StringLength(256, ErrorMessage = "Location cannot exceed 256 characters.")]
        public string Location { get; set; }

        public WarehouseViewModel() 
        {

        }

        public WarehouseViewModel(Warehouse warehouse)
        {
            Id = warehouse.Id;
            Name = warehouse.Name;
            Location = warehouse.Location;
        }
    }
}
