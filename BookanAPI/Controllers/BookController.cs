using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper) { 
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int pageNumber) {
            var books = await _bookService.GetAll(search, pageNumber);
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            Book book = await _bookService.GetById(id);
            return Ok(book);
        }

        [HttpPost("add")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> Add([FromBody] BookDTO book) {
            await _bookService.Add(_mapper.Map<Book>(book));
            return Ok();
        }


    }
}
