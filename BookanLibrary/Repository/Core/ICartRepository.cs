using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface ICartRepository : IBaseRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetUserCart(int userId);
    }
}
