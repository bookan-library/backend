using BookanLibrary.Core.Model;

namespace BookanAPI.DTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }
    }
}
