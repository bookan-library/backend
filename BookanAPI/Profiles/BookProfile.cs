using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;

namespace BookanAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
        }
    }
}
