using AutoMapper;
using BookanAPI.DTO;
using BookanLibrary.Core.Model;

namespace BookanAPI.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<FullCommentDTO, Comment>();
            CreateMap<Comment, FullCommentDTO>();
        }
    }
}
