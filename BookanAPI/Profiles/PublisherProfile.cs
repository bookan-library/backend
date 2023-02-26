using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;

namespace BookanAPI.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile() {
            CreateMap<PublisherDTO, Publisher>();
            CreateMap<Publisher, PublisherDTO>();
        }
    }
}
