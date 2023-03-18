using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Core.Model;

namespace BookanAPI.DTO
{
    public class FullCommentDTO
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public Book Book { get; set; }
        public string Nickname { get; set; }
        public string Content { get; set; }
        public CommentStatus Approved { get; set; }
    }
}
