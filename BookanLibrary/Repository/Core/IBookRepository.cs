using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> Search(QueryParams parameters);
        Task<IEnumerable<Book>> GetByCategory(string category, QueryParams parameters);
        Task<IEnumerable<Book>> GetAll(string category, QueryParams parameters);
    }
}
