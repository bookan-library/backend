using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Enums;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        }

        public async Task AddComment(Comment comment)
        {
            await _unitOfWork.CommentRepostiory.Add(comment);
        }

        public async Task<Comment> GetById(int id) { 
            return await _unitOfWork.CommentRepostiory.Get(id);
        }

        public async Task Approve(int commentId, CommentStatus isApproved) {
            Comment comment = await GetById(commentId);
            comment.Approved = isApproved;
            await _unitOfWork.CommentRepostiory.Update(comment);
        }

        public async Task<IEnumerable<Comment>> GetComments(int bookId)
        {
            IEnumerable<Comment> comments = await _unitOfWork.CommentRepostiory.GetCommentsForBook(bookId);
            return comments;
        }

        public async  Task<IEnumerable<Comment>> GetPendingComments()
        {
            IEnumerable<Comment> comments = await _unitOfWork.CommentRepostiory.GetPendingComments();
            return comments;
        }
    }
}
