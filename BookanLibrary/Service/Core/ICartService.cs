using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface ICartService
    {
        Task<IEnumerable<CartItem>> GetUserCart(int id);
        Task AddToCart(CartItem cartItem);
        Task RemoveFromCart(int id);
    }
}
