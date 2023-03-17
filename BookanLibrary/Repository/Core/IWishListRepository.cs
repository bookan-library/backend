using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface IWishListRepository : IBaseRepository<Wish>
    {
        Task<IEnumerable<Wish>> GetAll(int pageNumber, int userId);
        Task<int> GetAll(int userId);
        Task<Wish> CheckIfBookInWishlist(int userId, int bookId);
        Task<Wish> GetWishToRemove(int userId, int bookId);
    }
}
