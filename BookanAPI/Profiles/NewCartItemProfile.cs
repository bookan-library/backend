using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;

namespace BookanAPI.Profiles
{
    public class NewCartItemProfile : Profile
    {
        public NewCartItemProfile()
        {
        //    CreateMap<NewCartItemDTO, CartItem>()
        //        .ForMember(d => d.Buyer.Id,
        //            opt =>
        //                opt.MapFrom(
        //                    s => s.BuyerId))
        //        .ForMember(d => d.Book.Id,
        //            opt =>
        //                opt.MapFrom(
        //                    s => s.BookId)); ;
        //    CreateMap<CartItem, NewCartItemDTO>()
        //        .ForMember(d => d.BuyerId,
        //            opt =>
        //                opt.MapFrom(
        //                    s => s.Buyer.Id))
        //        .ForMember(d => d.BuyerId,
        //            opt =>
        //                opt.MapFrom(
        //                    s => s.Buyer.Id));
        }
    }
}
