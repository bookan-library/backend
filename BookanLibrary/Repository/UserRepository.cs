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
        public UserRepository(DataContext context) : base(context) { }
    }
}
