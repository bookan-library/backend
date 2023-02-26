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
        Task<IEnumerable<Book>> GetAll(string? search);
        Task Add(Book book);
        Task<Book> GetById(int id);
    }
}
