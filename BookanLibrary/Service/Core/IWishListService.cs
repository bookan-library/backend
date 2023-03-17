using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface IWishListService
    {
        Task<IEnumerable<Wish>> Get(int userId, int pageNumber);
        Task Add(Wish wish);
        Task Remove(int userId, int bookId);
        Task<Wish> GetById(int id);
        Task<bool> CheckIfBookInWishlist(int userId, int bookId);
        Task<int> GetCount(int userId);
    }
}
