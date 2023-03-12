using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
