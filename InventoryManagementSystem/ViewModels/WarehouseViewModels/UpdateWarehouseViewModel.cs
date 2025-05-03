namespace InventoryManagementSystem.ViewModels.WarehouseViewModels
{
    public class UpdateWarehouseViewModel
    {
        [StringLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        public string? Name { get; set; }

        [StringLength(256, ErrorMessage = "Location cannot exceed 256 characters.")]
        public string? Location { get; set; }

        public UpdateWarehouseViewModel()
        {

        }

        public UpdateWarehouseViewModel(Warehouse warehouse)
        {
            Name = warehouse.Name;
            Location = warehouse.Location;
        }
        public void UpdateEntity(Warehouse warehouse) 
        {
            if(Name != null)
            {
                warehouse.Name = Name;
            }
            if (Location != null)
            {
                warehouse.Location = Location;
            }
        }
    }
}
