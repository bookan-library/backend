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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> GetAll(string? search, int pageNumber)
        {
            return search == null ? await _unitOfWork.BookRepository.GetAll(pageNumber) : await _unitOfWork.BookRepository.Search(search, pageNumber);
        }

        public async Task Add(Book book) {
           await _unitOfWork.BookRepository.Add(book);
        }

        public async Task<Book> GetById(int id) {
            Book book = await _unitOfWork.BookRepository.Get(id);
            return book;
        }
    }
}
