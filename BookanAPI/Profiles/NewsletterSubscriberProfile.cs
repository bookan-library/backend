using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Newsletter;

namespace BookanAPI.Profiles
{
    public class NewsletterSubscriberProfile : Profile
    {
        public NewsletterSubscriberProfile()
        {
            CreateMap<NewsletterSubscriberDTO, NewsletterSubscriber>();
            CreateMap<NewsletterSubscriber, NewsletterSubscriberDTO>();
        }
    }
}
