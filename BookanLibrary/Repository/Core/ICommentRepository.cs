using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsForBook(int bookId);
        Task<IEnumerable<Comment>> GetPendingComments();

    }
}
