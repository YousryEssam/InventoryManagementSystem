using System.IdentityModel.Tokens.Jwt;

namespace InventoryManagementSystem.ViewModels.AccountViewModels
{
    public class AccountLoginViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; }
        public string Role { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
