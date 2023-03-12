using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAll();
        Task<Publisher> GetById(int id);
        Task Add(Publisher publisher);
    }
}
