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
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }    
        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _unitOfWork.CategoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id) {
            return await _unitOfWork.CategoryRepository.Get(id);
        }
    }
}
