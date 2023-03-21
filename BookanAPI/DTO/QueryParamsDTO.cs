namespace BookanAPI.DTO
{
    public class QueryParamsDTO
    {
        public string[]? Publishers { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set;}
        public int PageNumber { get; set;}
        public string? Search { get; set; }
    }
}
