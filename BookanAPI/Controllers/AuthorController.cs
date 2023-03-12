using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper) {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> GetAuthors() {
           return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(await _authorService.GetAll())); 
        }

        [HttpPost("add")]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> Add([FromBody] AuthorDTO author) {
            await _authorService.Add(_mapper.Map<Author>(author));
            return Ok();
        }


    }
}
