using AutoMapper;
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
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IBookService bookService, IUserService userService, IMapper mapper) {
            _commentService = commentService;
            _bookService = bookService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO comment) {
            Buyer buyer = await _userService.GetBuyer(comment.BuyerId);
            Book book = await _bookService.GetById(comment.BookId);
            await _commentService.AddComment(new Comment(buyer, book, comment.Nickname, comment.Comment));
            return Ok();
        }

        [HttpPatch("approve")]
        [Authorize(Roles = "MANAGER")]
        public async Task<IActionResult> ApproveComment([FromBody] ApproveCommentDTO commentDTO) {
            await _commentService.Approve(commentDTO.Id, commentDTO.IsApproved);
            return Ok();
        }

        [HttpGet("pending")]
        //[Authorize(Roles = "MANAGER")]
        public async Task<IActionResult> GetPendingComments()
        {
            IEnumerable<FullCommentDTO> pendingComments = _mapper.Map<IEnumerable<FullCommentDTO>>(await _commentService.GetPendingComments());
            return Ok(pendingComments);
        }

        [HttpGet("{bookId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComments([FromRoute] int bookId) {
            return Ok(await _commentService.GetComments(bookId));
        }

  
    }
}
