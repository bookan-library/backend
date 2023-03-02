using BookanLibrary.Core.Model.Newsletter;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service
{
    public class NewsletterService : INewsletterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsletterService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task Subscribe(NewsletterSubscriber subscriber) {
            await _unitOfWork.NewsletterSubscriberRepository.Add(subscriber);
        }
    }
}
