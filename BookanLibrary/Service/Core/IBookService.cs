using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll(string? search, int pageNumber);
        Task Add(Book book, byte[] file, string extension);
        Task<Book> GetById(int id);
        Task<IEnumerable<Book>> GetByCategory(string category, int pageNumber);
    }
}
