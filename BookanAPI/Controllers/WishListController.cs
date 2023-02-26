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
        public WishListController(IWishListService wishListService, UserManager<ApplicationUser> userManager, IBookService bookService) {
            _wishListService = wishListService;
            _userManager = userManager;
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] string buyerEmail) {
            ApplicationUser user = await _userManager.FindByNameAsync(buyerEmail);
            if (user == null) return BadRequest();
            IEnumerable<Wish> wishes = new List<Wish>();
            wishes = await _wishListService.Get(pageNumber, user.Id);
            return Ok(wishes);
        }

        //[HttpPost("/add")]
        //[Authorize(Roles = "BUYER")]
        //public async Task<IActionResult> Add([FromBody] WishDTO wishDTO) { 
        //    ApplicationUser user = await _userManager.FindByNameAsync(wishDTO.UserEmail);
        //    Book book = await _bookService.GetById(wishDTO.BookId);
        //    await _wishListService.Add(new Wish(user, book));

        //}

    }
}
