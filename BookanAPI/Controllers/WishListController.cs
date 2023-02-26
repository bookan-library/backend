using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            IBookService bookService, UserManager<ApplicationUser> userManager) {
            _wishListService = wishListService;
            _bookService = bookService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] string buyerEmail) {
            ApplicationUser user = await _userManager.FindByNameAsync(buyerEmail);
            if (user == null) return BadRequest();
            IEnumerable<Wish> wishes = new List<Wish>();
            wishes = await _wishListService.Get(user.Id, pageNumber);
            return Ok(wishes);
        }

        [HttpPost("/add")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Add([FromBody] WishDTO wishDTO)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(wishDTO.UserEmail);
            Buyer buyer = await _userService.GetBuyer(user.Id);
            Book book = await _bookService.GetById(wishDTO.BookId);
            await _wishListService.Add(new Wish(buyer, book));
            return Ok();
        }

    }
}
