using BookanAPI.EmailServices;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Newsletter;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using BookanLibrary.Shared;
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
        private readonly IEmailService _emailService;
        private readonly IStorageService _storageService;
        public NewsletterService(IUnitOfWork unitOfWork, IEmailService emailService, IStorageService storageService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _storageService = storageService;
        }

        public async Task SendNewsletter(Newsletter newsletter, byte[] file, string extension)
        {
            string filename = $"{newsletter.Title}-{DateTime.Now.ToString("ddMMyyyyhhmmss")}.{extension}";
            string picUrl = await _storageService.UploadFile(file, filename);
            newsletter.PicUrl = picUrl;
            await _unitOfWork.NewsLetterRepository.Add(newsletter);
            IEnumerable<NewsletterSubscriber> subscribers = await _unitOfWork.NewsletterSubscriberRepository.GetAll();
            foreach (NewsletterSubscriber subscriber in subscribers) {
                await _emailService.SendNewsletterEmail(newsletter, subscriber.SubscriberEmail);
            }
        }

        public async Task Subscribe(NewsletterSubscriber subscriber) {
            await _unitOfWork.NewsletterSubscriberRepository.Add(subscriber);
        }

        public async Task Unsubscribe(NewsletterSubscriber subscriber)
        {
            subscriber = await _unitOfWork.NewsletterSubscriberRepository.GetByEmail(subscriber.SubscriberEmail);
            subscriber.Deleted = true;
            await _unitOfWork.NewsletterSubscriberRepository.Update(subscriber);
        }
    }
}
