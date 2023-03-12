using BookanLibrary.Shared;

namespace BookanAPI.Services
{
    public class StorageService : IStorageService
    {
        private readonly Supabase.Client _client;
        public StorageService(IConfiguration configuration)
        {
            _client = new Supabase.Client(configuration["Supabase:Url"], configuration["Supabase:Secret"]);
        }
        public async Task<string> UploadFile(byte[] file, string filename)
        {
            var bucket = _client.Storage.From("books");
            var path = await bucket.Upload(file, filename);
            var url =  bucket.GetPublicUrl(filename);
            return url;
        }
    }
}
