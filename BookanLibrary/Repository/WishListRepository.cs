using BookanAPI.Extensions;
using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class WishListRepository : BaseRepository<Wish>, IWishListRepository
    {
        private readonly DataContext _context;
        public WishListRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wish>> GetAll(int pageNumber, int userId) {
            return _context.Set<Wish>()
               .Where(x => !x.Deleted && x.Buyer.Id == userId)
               .Include(x => x.Buyer)
               .Include(x => x.Book)
               .ThenInclude(x => x.Category)
               .Include(x => x.Book)
               .ThenInclude(x => x.Author)
               .Paginate(pageNumber, 10)
               .ToList();
        }

        public async Task<int> GetAll(int userId)
        {
            return _context.Set<Wish>()
               .Where(x => !x.Deleted && x.Buyer.Id == userId)
               .Include(x => x.Book)
               .Include(x => x.Buyer)
               .Count();
        }

        public async Task<Wish> CheckIfBookInWishlist(int userId, int bookId) {
            return await _context.Set<Wish>()
                   .Where(x => !x.Deleted && x.Buyer.Id == userId && x.Book.Id == bookId)
                   .FirstOrDefaultAsync();
        }

        public async Task<Wish> GetWishToRemove(int userId, int bookId)
        {
            return await _context.Set<Wish>()
                   .Where(x => !x.Deleted && x.Buyer.Id == userId && x.Book.Id == bookId)
                   .FirstOrDefaultAsync();
        }
    }
}
