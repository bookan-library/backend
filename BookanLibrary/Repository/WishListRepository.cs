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
               .Include(x => x.Book)
               .Include(x => x.Buyer)
               .Paginate(pageNumber, 10)
               .ToList();
        }

    }
}
