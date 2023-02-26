using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Migrations;
using BookanLibrary.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            return _context.Set<Book>()
                .Where(x => !(x as Entity).Deleted)
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .ToList();
        }
        public async Task<IEnumerable<Book>> Search(string search) {
            return _context.Set<Book>()
                .Where(x => !(x as Entity).Deleted && (x.Name.ToLower().Contains(search.ToLower())
                        || (x.Author.FirstName + " " + x.Author.LastName).ToLower().Contains(search.ToLower())))
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .ToList();
        } 
    }
}
