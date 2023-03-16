using BookanLibrary.Core.Model;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using BookanLibrary.Shared;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;
        public BookService(IUnitOfWork unitOfWork, IStorageService storageService) {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        public async Task<IEnumerable<Book>> GetAll(string? search, int pageNumber)
        {
            return search == null ? await _unitOfWork.BookRepository.GetAll(pageNumber) : await _unitOfWork.BookRepository.Search(search, pageNumber);
        }

        public async Task Add(Book book, byte[] file, string extension) {
            string filename = $"{book.Name}-{DateTime.Now.ToString("ddMMyyyyhhmmss")}.{extension}";
            string picUrl = await _storageService.UploadFile(file, filename);
            book.PicUrl = picUrl;
            await _unitOfWork.BookRepository.Add(book);
        }

        public async Task<Book> GetById(int id) {
            Book book = await _unitOfWork.BookRepository.Get(id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetByCategory(string category, int pageNumber) {
            return await _unitOfWork.BookRepository.GetByCategory(category, pageNumber);
        }

        public async Task<int> GetCount()
        {
            List<Book> books = (List<Book>)await _unitOfWork.BookRepository.GetAll();
            return books.Count;
        }
    }
}
