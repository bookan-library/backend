using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context) {
            _context = context;
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task AddBuyer(Buyer buyer) {
            Console.WriteLine("stiglo " + buyer.BoughtBooksNum);
            _context.Buyers.Add(buyer);
            _context.SaveChanges();
        }
    }
}
