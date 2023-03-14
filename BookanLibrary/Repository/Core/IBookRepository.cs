﻿using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> Search(string search, int pageNumber);
        Task<IEnumerable<Book>> GetByCategory(string category, int pageNumber);
    }
}
