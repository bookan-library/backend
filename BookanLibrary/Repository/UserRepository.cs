using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Migrations;
using BookanLibrary.Repository.Core;
using Microsoft.EntityFrameworkCore;
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
            _context.Buyers.Add(buyer);
            _context.SaveChanges();
        }

        public async Task<Buyer> GetBuyer(int id) {
            return _context.Set<Buyer>().Find(id);
        }

        public async Task<ApplicationUser> GetUser(int id)
        {
            return _context.Set<ApplicationUser>()
                .Where(x => x.Id == id)
                .Include(x => x.Address)
                .FirstOrDefault();
        }
    }
}
