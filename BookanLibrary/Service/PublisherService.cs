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
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublisherService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Publisher>> GetAll()
        {
            return await _unitOfWork.PublisherRepository.GetAll();
        }

        public async Task<Publisher> GetById(int id) {
            return await _unitOfWork.PublisherRepository.Get(id);
        }
    }
}
