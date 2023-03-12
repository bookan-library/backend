using BookanLibrary.Core.Model;

namespace BookanAPI.DTO
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
