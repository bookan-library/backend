using AutoMapper;
using BookanAPI.DTO;
using BookanAPI.Helpers;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper, IPublisherService publisherService,
            IAuthorService authorService, ICategoryService categoryService) { 
            _bookService = bookService;
            _mapper = mapper;
            _authorService = authorService;
            _categoryService = categoryService;
            _publisherService = publisherService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamsDTO parametersDTO) {
            QueryParams parameters = new QueryParams
            {
                Publishers = parametersDTO.Publishers,
                MinPrice = parametersDTO.MinPrice,
                MaxPrice = parametersDTO.MaxPrice,
                Search = parametersDTO.Search,
                PageNumber = parametersDTO.PageNumber,
            };
            var books = await _bookService.GetAll(parameters);
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            Book book = await _bookService.GetById(id);
            return Ok(book);
        }

        [HttpGet("categories/{category}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategory([FromRoute] string category, [FromQuery] QueryParamsDTO parametersDTO) {
            QueryParams parameters = new QueryParams
            {
                Publishers = parametersDTO.Publishers ?? new string[] {""},
                MinPrice = parametersDTO.MinPrice,
                MaxPrice = parametersDTO.MaxPrice,
                Search = parametersDTO.Search,
                PageNumber = parametersDTO.PageNumber,
            };
            return Ok(_mapper.Map<IEnumerable<BookDTO>>(await _bookService.GetByCategory(category, parameters)));
        }

        [HttpGet("{category}/count")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCount([FromRoute] string category, [FromQuery] QueryParamsDTO parametersDTO) {

            QueryParams parameters = new QueryParams
            {
                Publishers = parametersDTO.Publishers,
                MinPrice = parametersDTO.MinPrice,
                MaxPrice = parametersDTO.MaxPrice,
                Search = parametersDTO.Search,
                PageNumber = parametersDTO.PageNumber,
            };
            return Ok(await _bookService.GetCount(category, parameters));
        }

        //[HttpPost("add")]
        //[Authorize(Roles = "SELLER")]
        //public async Task<IActionResult> Add([FromBody] AddBookDTO bookDTO) {
        //    Book book = new Book {
        //        Name = bookDTO.Name, 
        //        Description = bookDTO.Description,
        //        PageNumber = bookDTO.PageNumber,  
        //        PublishingYear = bookDTO.PublishingYear,
        //        Author = await _authorService.GetById(bookDTO.AuthorId),  
        //        Publisher = await _publisherService.GetById(bookDTO.PublisherId),  
        //        Category = await _categoryService.GetById(bookDTO.CategoryId),  
        //        PicUrl = bookDTO.PicUrl
        //    };
        //    await _bookService.Add(book);
        //    return Ok();
        //}

        [HttpPost("add")]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> Add([FromForm]AddBookDTO bookDTO) {
            Book book = new Book
            {
                Name = bookDTO.Name,
                Description = bookDTO.Description,
                PageNumber = bookDTO.PageNumber,
                PublishingYear = bookDTO.PublishingYear,
                Author = await _authorService.GetById(bookDTO.AuthorId),
                Publisher = await _publisherService.GetById(bookDTO.PublisherId),
                Category = await _categoryService.GetById(bookDTO.CategoryId),
                Price = bookDTO.Price
            };
            var extension = bookDTO.File.FileName.Split('.').Last();
            var byteFile = await Helper.ConvertToByteArrayAsync(bookDTO.File);
            await _bookService.Add(book, byteFile, extension);
            return Ok();
        }

    }
}
