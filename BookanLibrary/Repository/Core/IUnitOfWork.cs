using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookanLibrary.Repository.Core.Newsletters;

namespace BookanLibrary.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        new void Dispose();

        public IUserRepository UserRepository { get; }
        public IBookRepository BookRepository { get; }
        public IWishListRepository WishListRepository { get; }
        public INewsletterRepository NewsLetterRepository { get; }
        public INewsletterSubscriberRepository NewsletterSubscriberRepository { get; }
    }
}
