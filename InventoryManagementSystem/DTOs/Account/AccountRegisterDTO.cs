namespace InventoryManagementSystem.DTOs.Account
{
    public class AccountRegisterDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters.")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 20 characters.")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address!.")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
