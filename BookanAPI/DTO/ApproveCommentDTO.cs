using BookanLibrary.Core.Model.Enums;

namespace BookanAPI.DTO
{
    public class ApproveCommentDTO 
    {
        public int Id { get; set; }
        public CommentStatus IsApproved { get; set; }
    }
}
