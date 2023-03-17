using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/wishlist")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;
        private readonly IBookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        public WishListController(IWishListService wishListService, IUserService userService,
            IBookService bookService, UserManager<ApplicationUser> userManager)
        {
            _wishListService = wishListService;
            _bookService = bookService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] string buyerEmail)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(buyerEmail);
            if (user == null) return BadRequest();
            IEnumerable<Wish> wishes = new List<Wish>();
            wishes = await _wishListService.Get(user.Id, pageNumber);
            return Ok(wishes);
        }

        [HttpGet("{userId}/count")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Get([FromRoute] int userId) {
            return Ok(await _wishListService.GetCount(userId));
        }


    [HttpPost("add")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Add([FromBody] WishDTO wishDTO)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(wishDTO.UserEmail);
            Buyer buyer = await _userService.GetBuyer(user.Id);
            Book book = await _bookService.GetById(wishDTO.BookId);
            await _wishListService.Add(new Wish(buyer, book));
            return Ok();
        }

        [HttpDelete("{bookId}")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Remove([FromRoute] int bookId)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userEmail = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser user = await _userManager.FindByNameAsync(userEmail);
            await _wishListService.Remove(user.Id, bookId);
            return Ok();
        }

        [HttpGet("check/{bookId}")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> CheckIfBookInWishlist([FromRoute] int bookId) {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userEmail = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
            ApplicationUser user = await _userManager.FindByNameAsync(userEmail);
            Console.WriteLine(await _wishListService.CheckIfBookInWishlist(user.Id, bookId));
            return Ok(await _wishListService.CheckIfBookInWishlist(user.Id, bookId));
        }

    }
}
