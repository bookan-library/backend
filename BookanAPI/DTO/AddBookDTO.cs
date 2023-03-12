namespace BookanAPI.DTO
{
    public class AddBookDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int PublishingYear { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File { get; set; }
    }
}
