using BookanLibrary.Core.Model;

namespace BookanAPI.DTO
{
    public class NewsletterDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public IFormFile File { get; set; }
    }
}
