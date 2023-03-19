using AutoMapper;
using BookanAPI.DTO;
using BookanAPI.Helpers;
using BookanLibrary.Core.Model;
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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterService newsletterService, IMapper mapper, IUserService userService)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("subscribe")]
        //[Authorize(Roles = "BUYER")]
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
        public async Task<IActionResult> SendNewsletter([FromForm] NewsletterDTO newsletterDTO) {
            Newsletter newsletter = new Newsletter {
                Title = newsletterDTO.Title,
                Content = newsletterDTO.Content,
                Creator = (Manager)await _userService.GetUser(newsletterDTO.CreatorId),
            };
            var extension = newsletterDTO.File.FileName.Split('.').Last();
            var byteFile = await Helper.ConvertToByteArrayAsync(newsletterDTO.File);
            await _newsletterService.SendNewsletter(newsletter, byteFile, extension);
            return Ok();
        }
   
    }
}
