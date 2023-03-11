using BookanAPI.Configurations;
using BookanAPI.DTO;
using BookanAPI.EmailServices;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ILookupNormalizer _normalizer;
        private readonly IUserService _userService;

        public AuthController(UserManager<ApplicationUser> userManager, IEmailService emailService,
            IConfiguration configuration, ILookupNormalizer normalizer, IUserService userService)
        {
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
            _normalizer = normalizer;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterBuyerDTO registerBuyerDTO) {
            if (ModelState.IsValid) {
                var user_exist = await _userManager.FindByEmailAsync(registerBuyerDTO.Email);
                if (user_exist != null) return BadRequest(new AuthResult { Result = false, Errors = new List<string>() { "Email already exists!" } });

                var new_user = new Buyer()
                {
                    UserName = registerBuyerDTO.Email,
                    Email = registerBuyerDTO.Email,
                    FirstName = registerBuyerDTO.FirstName,
                    LastName = registerBuyerDTO.LastName,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerBuyerDTO.Password),
                    PhoneNumber = registerBuyerDTO.PhoneNumber,
                    Role = Role.BUYER,
                    Address = registerBuyerDTO.Address,
                    BoughtBooksNum = 0
                };

                var result = await _userManager.CreateAsync(new_user, registerBuyerDTO.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(new_user);
                    code = Base64Encode(code);
                    await _emailService.SendVerificationMail(code, new_user.Email, new_user.Id);
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO user) {

            var foundUser = await _userManager.FindByNameAsync(user.Email);
            if (foundUser != null && BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password))
            {
                var issuer = _configuration["JwtConfig:Issuer"];
                var audience = _configuration["JwtConfig:Audience"];
                var key = Encoding.ASCII.GetBytes
                (_configuration["JwtConfig:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", foundUser.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, foundUser.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(new AuthResult() {
                    Token = stringToken, 
                    Result = true,
                    Errors = null 
                });
            }
            return Unauthorized();
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string code, [FromQuery] string id) {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            string _code = Base64Decode(code);
            var res = await _userManager.ConfirmEmailAsync(user, _code);
            return Ok();
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser() {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userEmail = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser user = await _userManager.FindByNameAsync(userEmail);
            UserDTO buyer = new UserDTO{
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role  = user.Role,
                Address = user.Address,
                EmailConfirmed = user.EmailConfirmed
            };
            return Ok(buyer);
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }



}
