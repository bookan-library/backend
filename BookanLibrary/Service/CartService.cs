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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CartItem>> GetUserCart(int id)
        {
            return await _unitOfWork.CartRepository.GetUserCart(id);
        }

        public async Task<CartItem> AddToCart(CartItem cartItem) {
            CartItem item = await _unitOfWork.CartRepository.CheckIfUserHasBookInCart(cartItem);
            if (item == null) { 
                await _unitOfWork.CartRepository.Add(cartItem);
                return cartItem;
            }
            item.Quantity += cartItem.Quantity;
            await _unitOfWork.CartRepository.Update(item);
            return item;
        }

        public async Task RemoveFromCart(int id)
        {
            CartItem item = await _unitOfWork.CartRepository.Get(id);
            item.Deleted = true;
            await _unitOfWork.CartRepository.Update(item);
        }

        public async Task UpdateInCart(CartItem cartItem)
        {
            CartItem item = await _unitOfWork.CartRepository.CheckIfUserHasBookInCart(cartItem);
            Console.WriteLine("item " + cartItem.Buyer.Id+ cartItem.Book.Id);
            item.Quantity = cartItem.Quantity;
            await _unitOfWork.CartRepository.Update(item);
        }
    }
}
