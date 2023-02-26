using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;

namespace BookanAPI.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() {
            CreateMap<AuthorDTO, Author>();
            CreateMap<Author, AuthorDTO>();
        }
    }
}
