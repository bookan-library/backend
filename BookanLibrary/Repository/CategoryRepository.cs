using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Migrations;
using BookanLibrary.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Category>> GetAll() {
            return _context.Set<Category>().Where(x => !(x as Entity).Deleted && x.CategoryParentId != null).ToList();
        }
    }
}
