namespace InventoryManagementSystem.DTOs.WarehouseDTOs
{
    public class UpdateWarehouseDTO
    {
        [StringLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        public string? Name { get; set; }

        [StringLength(256, ErrorMessage = "Location cannot exceed 256 characters.")]
        public string? Location { get; set; }

        public Warehouse GetWarehouse(int id)
        {
            return new Warehouse()
            {
                Id = id,
                Name = Name,
                Location = Location,
            };
        }
    }
}
