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
    public class CartRepository : BaseRepository<CartItem>, ICartRepository
    {
        private readonly DataContext _context;
        public CartRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetUserCart(int userId)
        {
            return _context.Set<CartItem>()
                .Where(x => !x.Deleted && x.Buyer.Id == userId)
                .Include(x => x.Book)
                .ToList();
        }

        public async Task<CartItem> CheckIfUserHasBookInCart(CartItem cartItem) {
            return _context.Set<CartItem>()
             .Where(x => !x.Deleted && x.Buyer.Id == cartItem.Buyer.Id && x.Book.Id == cartItem.Book.Id)
             .Include(x => x.Book)
             .FirstOrDefault();
        }
    }
}
