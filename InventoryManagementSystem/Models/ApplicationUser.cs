namespace InventoryManagementSystem.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters.")]
        public string FirstName { get; set; }
        
        
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 20 characters.")]
        public string LastName { get; set; }


        public bool IsDeleted { get; set; } = false;


        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<InventoryTransaction> Transactions { get; set; }
    }
}
