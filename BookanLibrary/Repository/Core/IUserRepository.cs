using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmail(string email);
        Task AddBuyer(Buyer buyer);
        Task<Buyer> GetBuyer(int id);
    }
}
