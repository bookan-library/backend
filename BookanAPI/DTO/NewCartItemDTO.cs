namespace BookanAPI.DTO
{
    public class NewCartItemDTO
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
