using BookanLibrary.Core.Model;
using BookanLibrary.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface IUserService
    {
        Task AddBuyer(Buyer buyer);
    }
}
