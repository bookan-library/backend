using BookanAPI.Extensions;
using BookanLibrary.Core.Model;
using BookanLibrary.Extensions;
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

        public async Task<IEnumerable<Book>> GetAll(string category, QueryParams parameters)
        {
            return _context.Set<Book>()
                .Where(x => !x.Deleted && x.Category.Name.ToLower().Equals(category.ToLower()))
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .FilterByPrice(parameters)
                .FilterByPublisher(parameters)
                //.Paginate(parameters.PageNumber, 10)
                .ToList();
        }

        public override async Task<Book> Get(int id) {
            return _context.Set<Book>()
                 .Where(x => x.Id == id)
                 .Include(x => x.Author)
                 .Include(x => x.Publisher)
                 .Include(x => x.Category)
                 .FirstOrDefault();
        }

        public async Task<IEnumerable<Book>> GetByCategory(string category, QueryParams parameters)
        {
            return _context.Set<Book>()
                .Where(x => !x.Deleted && x.Category.Name.ToLower().Equals(category.ToLower()))
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .FilterByPrice(parameters)
                .FilterByPublisher(parameters)
                .Paginate(parameters.PageNumber, 10)
                .ToList();
        }

        public async Task<IEnumerable<Book>> Search(QueryParams parameters) {
            return _context.Set<Book>()
                .Where(x => !x.Deleted && (x.Name.ToLower().Contains(parameters.Search.ToLower())
                        || (x.Author.FirstName + " " + x.Author.LastName).ToLower().Contains(parameters.Search.ToLower())))
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .FilterByPrice(parameters)
                .FilterByPublisher(parameters)
                .Paginate(parameters.PageNumber, 10)
                .ToList();
        }

    }





}
