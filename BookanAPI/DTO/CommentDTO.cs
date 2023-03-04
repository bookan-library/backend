namespace BookanAPI.DTO
{
    public class CommentDTO
    {
        public int BookId { get; set; }
        public int BuyerId { get; set; }
        public string Comment { get; set; }
        public string Nickname { get; set; }
    }
}
