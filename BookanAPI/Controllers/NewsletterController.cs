using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model.Newsletter;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Runtime.CompilerServices;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/newsletter")]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterService newsletterService, IMapper mapper)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
        }

        [HttpPost("subscribe")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> SubscribeToNewsletter([FromBody] NewsletterSubscriberDTO subscriberDTO)
        {
            await _newsletterService.Subscribe(_mapper.Map<NewsletterSubscriber>(subscriberDTO));
            return Ok();
        }

        [HttpDelete("unsubscribe")]
        [Authorize(Roles = "BUYER")]
        public async Task<IActionResult> UnsubscribeToNewsletter([FromBody] NewsletterSubscriberDTO subscriberDTO) {
            await _newsletterService.Unsubscribe(_mapper.Map<NewsletterSubscriber>(subscriberDTO));
            return Ok();
        }

        [HttpPost("send")]
        [Authorize(Roles = "MANAGER")]
        public async Task<IActionResult> SendNewsletter([FromBody] NewsletterDTO newsletter) {
            Newsletter n = _mapper.Map<Newsletter>(newsletter);
            Console.WriteLine("n " + n);
            await _newsletterService.SendNewsletter(_mapper.Map<Newsletter>(newsletter));
            return Ok();

        }
    }
}
