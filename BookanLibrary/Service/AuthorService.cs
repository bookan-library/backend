using BookanLibrary.Core.Model;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Author author)
        {
           await _unitOfWork.AuthorRepository.Add(author);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _unitOfWork.AuthorRepository.GetAll();
        }

        public async Task<Author> GetById(int id) {
            return await _unitOfWork.AuthorRepository.Get(id);
        }
    }
}
