using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model.Newsletter;

namespace BookanAPI.Profiles
{
    public class NewsletterProfile : Profile
    {
        public NewsletterProfile()
        {
            CreateMap<NewsletterDTO, Newsletter>().ForMember(d => d.Id,
                    opt =>
                        opt.MapFrom(
                            s => s.CreatorId));
            CreateMap<Newsletter, NewsletterDTO>().ForMember(d => d.CreatorId,
                    opt =>
                        opt.MapFrom(
                            s => s.Creator.Id));
        }
    }
}
