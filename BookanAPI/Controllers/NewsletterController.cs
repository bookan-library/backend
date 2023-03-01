using BookanAPI.DTO;
using BookanLibrary.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace BookanAPI.Controllers
{
    [ApiController]
    [Route("/api/newsletter")]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _newsletterService;
        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribeToNewsletter([FromBody] NewsletterDTO newsletterDTO)
        {
            throw new NotImplementedException();
        }
    }
}
