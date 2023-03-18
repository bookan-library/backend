using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Helpers;
using BookanLibrary.Migrations;
using BookanLibrary.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly DataContext _context;
        public CommentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsForBook(int bookId) {
            return _context.Set<Comment>()
                .Where(x => !(x as Entity).Deleted && x.Book.Id == bookId && x.Approved == CommentStatus.APPROVED)
                .ToList();
        }

        public async Task<IEnumerable<Comment>> GetPendingComments()
        {
            return _context.Set<Comment>()
                .Where(x => !(x as Entity).Deleted && x.Approved == CommentStatus.PENDING)
                .Include(x => x.Buyer)
                .Include(x => x.Book)
                .ThenInclude(x => x.Author)
                .Include(x => x.Book)
                .ThenInclude(x => x.Category)
                .ToList();
        }
    }
}
