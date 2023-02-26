using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Service.Core;
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
        public async Task<IActionResult> GetAll([FromQuery] string? search) {
            var books = await _bookService.GetAll(search);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            Book book = await _bookService.GetById(id);
            return Ok(book);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BookDTO book) {
            await _bookService.Add(_mapper.Map<Book>(book));
            return Ok();
        }


    }
}
