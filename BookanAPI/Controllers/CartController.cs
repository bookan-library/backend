using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public CartController(ICartService cartService, IUserService userService, IMapper mapper, IBookService bookService) {
            _cartService = cartService;
            _userService = userService;
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "BUYER")]
        public async Task<IActionResult> GetUserCart([FromRoute] int id) {
            //map
            IEnumerable<CartItemDTO> cartItems = _mapper.Map<IEnumerable<CartItemDTO>>(await _cartService.GetUserCart(id));
            return Ok(cartItems);
        }

        [HttpPost("add")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> AddToCart([FromBody] NewCartItemDTO newCartItem) {
            Book book = await _bookService.GetById(newCartItem.BookId);
            Buyer buyer = await _userService.GetBuyer(newCartItem.BuyerId);
            return Ok(await _cartService.AddToCart(new CartItem(buyer, book, newCartItem.Quantity)));
        }

        [HttpPost("update")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> UpdateInCart([FromBody] NewCartItemDTO cartItem) {
            Book book = await _bookService.GetById(cartItem.BookId);
            Buyer buyer = await _userService.GetBuyer(cartItem.BuyerId);
            await _cartService.UpdateInCart(new CartItem(buyer, book, cartItem.Quantity));
            return Ok();
        }

        [HttpDelete("{cartItemId}/remove")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> RemoveFromCart([FromRoute] int cartItemId) {
            await _cartService.RemoveFromCart(cartItemId);
            return Ok();
        }

    }
}
