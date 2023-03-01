using BookanLibrary.Core.Model;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Buyer> GetBuyer(int id) {
            return await _unitOfWork.UserRepository.GetBuyer(id);
        }

        public async Task AddBuyer(Buyer buyer) {
            await _unitOfWork.UserRepository.AddBuyer(buyer);
        }
    }
}
