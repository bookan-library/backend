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
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WishListService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Wish wish)
        {
            await _unitOfWork.WishListRepository.Add(wish);
        }

        public async Task<IEnumerable<Wish>> Get(int userId, int pageNumber)
        {
            return await _unitOfWork.WishListRepository.GetAll(pageNumber, userId);
        }

        public async Task<Wish> GetById(int id)
        {
            return await _unitOfWork.WishListRepository.Get(id);
        }

        public async Task Remove(Wish wish)
        {
            wish.Deleted = true;
            await _unitOfWork.WishListRepository.Update(wish);
        }
    }
}
