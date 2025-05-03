namespace InventoryManagementSystem.DTOs.WarehouseDTOs
{
    public class NewWarehouseDTO
    {
        [Required]
        [StringLength(128, ErrorMessage = "Name cannot exceed 128 characters.")]
        public string Name { get; set; }


        [Required]
        [StringLength(256, ErrorMessage = "Location cannot exceed 256 characters.")]
        public string Location { get; set; }


        public Warehouse GetWarehouse() 
        {
            return new Warehouse()
            {
                Name = Name,
                Location = Location,
            };
        }
    }
}
