using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseAPIController
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager , IMediator mediator) :base(mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ResponseViewModel<AccountRegisterViewModel>> Register(AccountRegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<AccountRegisterViewModel>(ErrorCode.ValidationError, "Validation Error");
            }

            await CreateRolesIfNotExist();

            ApplicationUser? existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (existingUser != null)
            {
                return await UnsuccessfulRequest<AccountRegisterViewModel>(ErrorCode.EmailAlreadyExists, "Email Already Exists");
            }

            ApplicationUser newApplicationUser = new ApplicationUser()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email.ToLower(),
            };

            var result = await _userManager.CreateAsync(newApplicationUser, registerDTO.Password);

            if (!result.Succeeded)
            {
                StringBuilder errorsDescription = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errorsDescription.AppendLine(error.Description);
                }
                return await UnsuccessfulRequest<AccountRegisterViewModel>(ErrorCode.UnExceptedError, errorsDescription.ToString());
            }

            AccountRegisterViewModel registerViewModel = new AccountRegisterViewModel() { Email = registerDTO.Email };

            if (registerDTO.Email == "admin@system.com")
            {
                registerViewModel.Role = "Admin";
                await _userManager.AddToRoleAsync(newApplicationUser, "Admin");
            }
            else
            {
                registerViewModel.Role = "User";
                await _userManager.AddToRoleAsync(newApplicationUser, "User");
            }
            return await SuccessfulRequest(registerViewModel, "Account Created Successfully");
        }

        [HttpPost("Login")]
        public async Task<ResponseViewModel<AccountLoginViewModel>> Login(AccountLoginDTO loginDTO)
        {
            if(!ModelState.IsValid)
            {
                return await UnsuccessfulRequest<AccountLoginViewModel>(ErrorCode.ValidationError, "Validation Error");
            }

            ApplicationUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) 
            {
                return await UnsuccessfulRequest<AccountLoginViewModel>(ErrorCode.InvalidData, "Incorrect  E-mail Or password.");
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if(!isPasswordValid)
            {
                return await UnsuccessfulRequest<AccountLoginViewModel>(ErrorCode.InvalidData, "Incorrect  E-mail Or password.");
            }

            var userRole = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in userRole)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            string? keyString = _configuration["JWT:Key"];
            if (keyString == null)
            {
                return await UnsuccessfulRequest<AccountLoginViewModel>(ErrorCode.UnExceptedError, "Unexcepted Error");
            }

            byte[]? keyBytes = Convert.FromBase64String(keyString);
            var JWTSigningKey = new SymmetricSecurityKey(keyBytes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                expires: loginDTO.RememberMeForMonth ? DateTime.Now.AddDays(30) : DateTime.Now.AddDays(1),
                claims: userClaims,
                signingCredentials: new SigningCredentials(JWTSigningKey, SecurityAlgorithms.HmacSha256)
            );

            AccountLoginViewModel loginViewModel = new AccountLoginViewModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = token.ValidTo,
                Username = user.UserName,
                Role = userRole[0]
            };
            return await SuccessfulRequest(loginViewModel, "Successful login");
        }

        /*********************** Helper Methods ***********************/
        private async Task CreateRolesIfNotExist()
        {
            string[] systemRoles = { "Admin", "User" };
            foreach (var role in systemRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int> { Name = role });
                }
            }
        }
    }
}
