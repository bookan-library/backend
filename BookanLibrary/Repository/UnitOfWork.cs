using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core;
using BookanLibrary.Repository.Core.Newsletters;
using BookanLibrary.Repository.Newsletters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private Dictionary<string, dynamic> _repositories;
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IWishListRepository _wishListRepository;
        private INewsletterRepository _newsletterRepository;
        private INewsletterSubscriberRepository _newsletterSubscriberRepository;


        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);
        public IWishListRepository WishListRepository => _wishListRepository ??= new WishListRepository(_context);
        public INewsletterRepository NewsLetterRepository => _newsletterRepository ??= new NewsletterRepository(_context);
        public INewsletterSubscriberRepository NewsletterSubscriberRepository => _newsletterSubscriberRepository ??= new NewsletterSubscriberRepository(_context);

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
