using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;

namespace BookanAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
