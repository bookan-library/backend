using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task Add(Author author);
        Task<Author> GetById(int id);
    }
}
