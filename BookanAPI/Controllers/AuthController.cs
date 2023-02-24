using BookanAPI.Configurations;
using BookanAPI.DTO;
using BookanAPI.EmailServices;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using RestSharp;
using System.Net;
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

        public AuthController(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterBuyerDTO registerBuyerDTO) {

            if (ModelState.IsValid) {
                var user_exist = await _userManager.FindByEmailAsync(registerBuyerDTO.Email);
                if (user_exist != null) return BadRequest(new AuthResult { Result = false, Errors = new List<string>() { "Email already exists!" } });

                var new_user = new ApplicationUser()
                {
                    UserName = registerBuyerDTO.Email,
                    Email = registerBuyerDTO.Email,
                    FirstName = registerBuyerDTO.FirstName,
                    LastName = registerBuyerDTO.LastName,
                    Password = registerBuyerDTO.Password,
                    PhoneNumber = registerBuyerDTO.PhoneNumber,
                    Role = Role.BUYER,
                    Address = registerBuyerDTO.Address
                };

                var result = await _userManager.CreateAsync(new_user, registerBuyerDTO.Password);
                if (result.Succeeded)
                {
                    Console.WriteLine(new_user.Id);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(new_user);
                    Console.WriteLine("Real code " + code);
                    code = Base64Encode(code);
                    await _emailService.SendVerificationMail(code, new_user.Email, new_user.Id);
                    //var res = await _userManager.ConfirmEmailAsync(new_user, HttpUtility.UrlDecode(code));
                    //Console.WriteLine("Testiramo hehe" + res);

                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string code, [FromQuery] string id) {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            Console.WriteLine(user);
            string _code = Base64Decode(code);
            Console.WriteLine(_code);
            var res = await _userManager.ConfirmEmailAsync(user, _code);
            Console.WriteLine("res " + res);
            return Ok();
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
