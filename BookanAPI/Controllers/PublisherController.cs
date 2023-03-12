using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/publishers")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;
        public PublisherController(IPublisherService publisherService, IMapper mapper) {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> GetAll() {
            return Ok(_mapper.Map<IEnumerable<PublisherDTO>>(await _publisherService.GetAll()));
        }

        [HttpPost("add")]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> Add(PublisherDTO publisherDTO) {
            await _publisherService.Add(_mapper.Map<Publisher>(publisherDTO));
            return Ok();
        }
    }
}
