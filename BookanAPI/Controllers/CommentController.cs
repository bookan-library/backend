using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Service;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public CommentController(ICommentService commentService, IBookService bookService, IUserService userService) {
            _commentService = commentService;
            _bookService = bookService;
            _userService = userService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO comment) {
            Buyer buyer = await _userService.GetBuyer(comment.BuyerId);
            Book book = await _bookService.GetById(comment.BookId);
            await _commentService.AddComment(new Comment(buyer, book, comment.Nickname, comment.Comment));
            return Ok();
        }
    }
}
