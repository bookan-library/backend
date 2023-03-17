using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface ICommentService
    {
        Task AddComment(Comment comment);
        Task<Comment> GetById(int id);
        Task Approve(int commentId, CommentStatus isApproved);
        Task<IEnumerable<Comment>> GetComments(int bookId);
    }
}
