namespace InventoryManagementSystem.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        [Required]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "Message must be between 3 and 256 characters.")]
        public string Message { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public bool IsMessageSent { get; set; } = false;

        // Navigation properties
        public virtual Product Product { get; set; }
    }
}
