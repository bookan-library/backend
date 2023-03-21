using BookanLibrary.Core.Model;

namespace BookanAPI.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int PublishingYear { get; set; }
        public AuthorDTO Author { get; set; }
        public PublisherDTO Publisher { get; set; }
        public CategoryDTO Category { get; set; }
        public string PicUrl { get; set; }
        public double Price { get; set; }
    }
}
